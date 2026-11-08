using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
namespace UI
{
    public partial class ucInventoryandSales : UserControl
    {
        DataGridView grid; ComboBox reportType,category,stockStatus;
        DateTimePicker start,end; Label count; DataTable current;
        public ucInventoryandSales() {InitializeComponent();Build();UiToolkit.Safe(LoadReport);}
        void Build()
        {
            var p=UiToolkit.Layout(this,"Inventory & Sales Reports",155);
            var bar=UiToolkit.Bar(); p.Controls.Add(bar,0,1);
            reportType=UiToolkit.Combo(bar,"Report",145); reportType.Items.AddRange(new object[]{"Inventory","Sales"}); reportType.SelectedIndex=0;
            category=UiToolkit.Combo(bar,"Category",160);
            stockStatus=UiToolkit.Combo(bar,"Stock",145); stockStatus.Items.AddRange(new object[]{"All","In Stock","Low Stock","Out of Stock"}); stockStatus.SelectedIndex=0;
            bar.Controls.Add(new Label {Text="From",AutoSize=true,Padding=new Padding(3,8,0,0)});
            start=new DateTimePicker {Width=135,Format=DateTimePickerFormat.Short,Value=DateTime.Today.AddDays(-30)};bar.Controls.Add(start);
            bar.Controls.Add(new Label {Text="To",AutoSize=true,Padding=new Padding(3,8,0,0)});
            end=new DateTimePicker {Width=135,Format=DateTimePickerFormat.Short,Value=DateTime.Today};bar.Controls.Add(end);
            UiToolkit.Button(bar,"Generate / Refresh",LoadReport);
            UiToolkit.Button(bar,"Print Preview",Preview);
            count=new Label {AutoSize=true,Font=new Font("Segoe UI",10,FontStyle.Bold),Padding=new Padding(5,8,0,0)};bar.Controls.Add(count);
            grid=UiToolkit.Grid();p.Controls.Add(grid,0,2);
            UiToolkit.BindCombo(category,AppServices.Categories.Lookup(),true);
        }
        void LoadReport()
        {
            if(Convert.ToString(reportType.SelectedItem)=="Inventory")
            {
                int? id=UiToolkit.SelectedId(category);if(id==0)id=null;
                string st=stockStatus.SelectedIndex<=0?null:Convert.ToString(stockStatus.SelectedItem);
                current=AppServices.Reports.Inventory(id,st);
                count.Text="Active inventory products: "+AppServices.Products.CountActiveInventoryItems();
            }
            else
            {
                if(start.Value.Date>end.Value.Date) throw new ArgumentException("End date must not be before start date.");
                // Inclusive local calendar dates => UTC half-open interval (Manila UTC+08).
                TimeZoneInfo tz;
                try{tz=TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");}
                catch(TimeZoneNotFoundException){tz=TimeZoneInfo.Local;}
                var from=TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(start.Value.Date,DateTimeKind.Unspecified),tz);
                var to=TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(end.Value.Date.AddDays(1),DateTimeKind.Unspecified),tz);
                current=AppServices.Reports.Sales(from,to);
                decimal sum=current.AsEnumerable().Sum(r=>r.IsNull("Total")?0:Convert.ToDecimal(r["Total"]));
                count.Text=current.Rows.Count+" transaction(s) | Total: ₱"+sum.ToString("N2");
            }
            grid.DataSource=current;
        }
        void Preview()
        {
            if(current==null) throw new InvalidOperationException("Generate a report first.");
            var print=new PrintDocument(); int next=0;
            print.BeginPrint+=(s,e)=>next=0;
            print.PrintPage+=(s,e)=>
            {
                float y=45;float x=35;
                using(var title=new Font("Segoe UI",14,FontStyle.Bold))
                    e.Graphics.DrawString("Café't Bahay — "+reportType.SelectedItem+" Report",title,Brushes.Black,x,y);
                y+=45;
                using(var f=new Font("Consolas",9))
                {
                    while(next<current.Rows.Count && y<e.MarginBounds.Bottom-40)
                    {
                        var r=current.Rows[next++];
                        string line=string.Join(" | ",r.ItemArray.Select(v=>Convert.ToString(v)));
                        // Avoid columns spilling off the printable page.
                        while(line.Length>98) {e.Graphics.DrawString(line.Substring(0,98),f,Brushes.Black,x,y);y+=16;line=line.Substring(98);}
                        e.Graphics.DrawString(line,f,Brushes.Black,x,y);y+=22;
                    }
                    if(current.Rows.Count==0)e.Graphics.DrawString("No records found.",f,Brushes.Black,x,y);
                }
                e.HasMorePages=next<current.Rows.Count;
            };
            using(var dlg=new PrintPreviewDialog{Document=print,Width=900,Height=650})dlg.ShowDialog(this);
        }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
