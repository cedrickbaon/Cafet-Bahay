using System;
using System.Windows.Forms;
namespace UI
{
    public partial class ucProductSearch : UserControl
    {
        DataGridView grid; TextBox keyword; ComboBox category; Label result;
        public ucProductSearch() { InitializeComponent(); Build(); UiToolkit.Safe(LoadData); }
        void Build()
        {
            var p=UiToolkit.Layout(this,"Product Search",95); var bar=UiToolkit.Bar(); p.Controls.Add(bar,0,1);
            keyword=UiToolkit.Text(bar,"Product name / keyword",220);
            category=UiToolkit.Combo(bar,"Category",185);
            UiToolkit.Button(bar,"Search",Search);
            UiToolkit.Button(bar,"Clear / Reset",()=>{ keyword.Clear(); category.SelectedIndex=0; Search(); });
            UiToolkit.Button(bar,"Refresh",LoadData);
            result=new Label {AutoSize=true, Padding=new Padding(8,7,0,0)}; bar.Controls.Add(result);
            grid=UiToolkit.Grid(); p.Controls.Add(grid,0,2);
        }
        void LoadData() { UiToolkit.BindCombo(category,AppServices.Categories.Lookup(),true); Search(); }
        void Search()
        {
            int? id=UiToolkit.SelectedId(category); if(id==0) id=null;
            var table=AppServices.Products.Search(keyword.Text.Trim(),id);
            grid.DataSource=table;
            if(grid.Columns.Contains("RowVersion")) grid.Columns["RowVersion"].Visible=false;
            result.Text=table.Rows.Count==0 ? "No Product Found" : table.Rows.Count+" product(s)";
        }
    }
}
