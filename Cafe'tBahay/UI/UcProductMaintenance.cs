using System;
using System.Data;
using System.Windows.Forms;
using Model;
namespace UI
{
    public partial class UcProductMaintenance : UserControl
    {
        DataGridView grid; TextBox name; ComboBox category,supplier,status;
        NumericUpDown price,stock; int editId; byte[] version;
        public UcProductMaintenance() { InitializeComponent(); Build(); UiToolkit.Safe(LoadData); }
        void Build()
        {
            var p=UiToolkit.Layout(this,"Product Maintenance",155); var bar=UiToolkit.Bar(); p.Controls.Add(bar,0,1);
            name=UiToolkit.Text(bar,"Product Name",130);
            category=UiToolkit.Combo(bar,"Category",145); supplier=UiToolkit.Combo(bar,"Supplier",145);
            price=UiToolkit.Num(bar,"Price",9999999999999999m,2);
            stock=UiToolkit.Num(bar,"Stock",100000000);
            status=UiToolkit.Combo(bar,"Status",95); status.Items.AddRange(new object[]{"Active","Inactive"}); status.SelectedIndex=0;
            UiToolkit.Button(bar,"Save Product",Save);
            UiToolkit.Button(bar,"Edit Selected",Edit);
            UiToolkit.Button(bar,"Deactivate",Deactivate);
            UiToolkit.Button(bar,"Clear",Clear);
            UiToolkit.Button(bar,"Refresh",LoadData);
            grid=UiToolkit.Grid(); p.Controls.Add(grid,0,2);
        }
        void LoadData()
        {
            UiToolkit.BindCombo(category,AppServices.Categories.Lookup());
            var suppliers=AppServices.Suppliers.GetAll();
            // GetAll returns Id/SupplierName, used by the combo box's display/value members.
            supplier.DataSource=suppliers; supplier.DisplayMember="SupplierName"; supplier.ValueMember="Id";
            grid.DataSource=AppServices.Products.GetAll();
            if(grid.Columns.Contains("RowVersion")) grid.Columns["RowVersion"].Visible=false;
        }
        void Edit()
        {
            var r=UiToolkit.Selected(grid); editId=UiToolkit.Id(r);
            name.Text=UiToolkit.Str(r,"Name"); category.SelectedValue=Convert.ToInt32(r["CategoryId"]);
            supplier.SelectedValue=Convert.ToInt32(r["SupplierId"]);
            price.Value=Math.Min(price.Maximum,Convert.ToDecimal(r["Price"]));
            stock.Value=Math.Min(stock.Maximum,Convert.ToDecimal(r["StockQuantity"]));
            status.SelectedItem=UiToolkit.Str(r,"Status");
            version=(byte[])r["RowVersion"];
        }
        void Clear() { editId=0; version=null; name.Clear(); price.Value=0; stock.Value=0; status.SelectedItem="Active"; grid.ClearSelection(); }
        void Save()
        {
            if(!UiToolkit.SelectedId(category).HasValue || !UiToolkit.SelectedId(supplier).HasValue)
                throw new InvalidOperationException("Create a category and supplier first.");
            var product=new Product { Id=editId, Name=name.Text.Trim(), CategoryId=UiToolkit.SelectedId(category).Value,
                SupplierId=UiToolkit.SelectedId(supplier).Value, Price=price.Value, StockQuantity=(int)stock.Value,
                Status=Convert.ToString(status.SelectedItem), RowVersion=version };
            if(editId==0) AppServices.Products.Add(product); else AppServices.Products.Update(product);
            LoadData(); Clear(); UiToolkit.Info("Product saved.");
        }
        void Deactivate()
        {
            int id=UiToolkit.Id(UiToolkit.Selected(grid));
            if(MessageBox.Show("Deactivate selected product?", "Confirm",MessageBoxButtons.YesNo)==DialogResult.Yes)
            { AppServices.Products.Deactivate(id); LoadData(); Clear(); }
        }
    }
}
