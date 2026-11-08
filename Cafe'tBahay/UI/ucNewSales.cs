using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
namespace UI
{
    public partial class ucNewSales : UserControl
    {
        DataGridView products, cartGrid;
        TextBox search; NumericUpDown quantity, payment; Label totalLabel, changeLabel;
        DataTable productTable;
        BindingList<SaleRow> cart=new BindingList<SaleRow>();
        Receipt lastReceipt;
        public ucNewSales() { InitializeComponent(); Build(); UiToolkit.Safe(RefreshProducts); }
        public class SaleRow
        {
            public int ProductId {get;set;}
            public string ProductName {get;set;}
            public int Quantity {get;set;}
            public decimal UnitPrice {get;set;}
            public decimal Subtotal {get {return UnitPrice*Quantity;} }
        }
        void Build()
        {
            var outer=UiToolkit.Layout(this,"New Sale / Cashier",155);
            var bar=UiToolkit.Bar(); outer.Controls.Add(bar,0,1);
            search=UiToolkit.Text(bar,"Search Product",160);
            quantity=UiToolkit.Num(bar,"Quantity",1000000); quantity.Minimum=1; quantity.Value=1;
            UiToolkit.Button(bar,"Search",SearchProducts);
            UiToolkit.Button(bar,"Refresh Products",RefreshProducts);
            UiToolkit.Button(bar,"Add Selected To Cart",AddToCart);
            UiToolkit.Button(bar,"Remove From Cart",RemoveFromCart);
            payment=UiToolkit.Num(bar,"Payment",9999999999999999m,2);
            payment.ValueChanged+=(s,e)=>UpdateTotals();
            totalLabel=new Label {AutoSize=true,Font=new Font("Segoe UI",11,FontStyle.Bold),Padding=new Padding(6,7,0,0)};
            changeLabel=new Label {AutoSize=true,Font=new Font("Segoe UI",11,FontStyle.Bold),Padding=new Padding(6,7,0,0)};
            bar.Controls.Add(totalLabel); bar.Controls.Add(changeLabel);
            UiToolkit.Button(bar,"Complete Sale",CompleteSale);
            UiToolkit.Button(bar,"Preview Last Receipt",PreviewReceipt);
            var split=new SplitContainer {Dock=DockStyle.Fill,Orientation=Orientation.Horizontal,SplitterDistance=230};
            products=UiToolkit.Grid(); cartGrid=UiToolkit.Grid(); cartGrid.DataSource=cart;
            var p1=new Panel {Dock=DockStyle.Fill}; p1.Controls.Add(products);
            p1.Controls.Add(new Label {Text="Available products (select a row)",Dock=DockStyle.Top,Height=25});
            var p2=new Panel {Dock=DockStyle.Fill}; p2.Controls.Add(cartGrid);
            p2.Controls.Add(new Label {Text="Current cart — stock is not deducted until payment succeeds",Dock=DockStyle.Top,Height=25});
            split.Panel1.Controls.Add(p1); split.Panel2.Controls.Add(p2); outer.Controls.Add(split,0,2);
            UpdateTotals();
        }
        void RefreshProducts(){ SearchProducts(); }
        void SearchProducts()
        {
            productTable=AppServices.Products.Search(search.Text.Trim());
            products.DataSource=productTable;
            if(products.Columns.Contains("RowVersion")) products.Columns["RowVersion"].Visible=false;
        }
        void AddToCart()
        {
            var p=UiToolkit.Selected(products);
            if(UiToolkit.Str(p,"Status")!="Active") throw new InvalidOperationException("Inactive product.");
            int id=UiToolkit.Id(p), qty=(int)quantity.Value;
            var existing=cart.FirstOrDefault(x=>x.ProductId==id);
            int requested=qty+(existing==null?0:existing.Quantity);
            if(requested>Convert.ToInt32(p["StockQuantity"])) throw new InvalidOperationException("Insufficient stock for requested quantity.");
            if(existing!=null) {existing.Quantity=requested; cart.ResetBindings();}
            else cart.Add(new SaleRow {ProductId=id,ProductName=UiToolkit.Str(p,"Name"),Quantity=qty,UnitPrice=Convert.ToDecimal(p["Price"])});
            UpdateTotals();
        }
        void RemoveFromCart()
        {
            if(cartGrid.CurrentRow==null) throw new InvalidOperationException("Choose a cart item.");
            var row=cartGrid.CurrentRow.DataBoundItem as SaleRow;
            if(row!=null) cart.Remove(row); UpdateTotals();
        }
        decimal Total {get{return cart.Sum(x=>x.Subtotal);}}
        void UpdateTotals()
        {
            totalLabel.Text="Total: ₱"+Total.ToString("N2");
            changeLabel.Text="Change: ₱"+Math.Max(0,payment.Value-Total).ToString("N2");
        }
        void CompleteSale()
        {
            if(cart.Count==0) throw new InvalidOperationException("Add at least one product.");
            if(payment.Value<Total) throw new InvalidOperationException("Payment is insufficient.");
            var items=cart.Select(x=>new CartItem{ProductId=x.ProductId,Quantity=x.Quantity}).ToList();
            lastReceipt=AppServices.Sales.CompleteSale(items,payment.Value);
            cart.Clear(); payment.Value=0; RefreshProducts(); UpdateTotals();
            UiToolkit.Info("Sale completed! Transaction: "+lastReceipt.TransactionNumber+"\nTotal: ₱"+lastReceipt.Total.ToString("N2")+"\nChange: ₱"+lastReceipt.Change.ToString("N2"));
            PreviewReceipt();
        }
        void PreviewReceipt()
        {
            if(lastReceipt==null) throw new InvalidOperationException("No receipt yet. Complete a sale first.");
            var print=new PrintDocument();
            print.PrintPage+=(s,e)=>
            {
                var sb=new StringBuilder();
                sb.AppendLine("CAFÉ'T BAHAY  •  SALES RECEIPT");
                sb.AppendLine("Transaction: "+lastReceipt.TransactionNumber);
                sb.AppendLine("Date (UTC): "+lastReceipt.SoldAtUtc.ToString("yyyy-MM-dd HH:mm"));
                sb.AppendLine("----------------------------------------");
                foreach(var r in lastReceipt.Lines)
                    sb.AppendLine(r.ProductName+"  x"+r.Quantity+" @ ₱"+r.UnitPrice.ToString("N2")+" = ₱"+r.Subtotal.ToString("N2"));
                sb.AppendLine("----------------------------------------");
                sb.AppendLine("TOTAL: ₱"+lastReceipt.Total.ToString("N2"));
                sb.AppendLine("PAID: ₱"+lastReceipt.Payment.ToString("N2"));
                sb.AppendLine("CHANGE: ₱"+lastReceipt.Change.ToString("N2"));
                sb.AppendLine("Thank you for your purchase!");
                using(var font=new Font("Consolas",10)) e.Graphics.DrawString(sb.ToString(),font,Brushes.Black,new RectangleF(35,35,e.MarginBounds.Width,e.MarginBounds.Height));
            };
            using(var preview=new PrintPreviewDialog {Document=print,Width=900,Height=650}) preview.ShowDialog(this);
        }
    }
}
