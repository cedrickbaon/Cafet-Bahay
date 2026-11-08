using System;
using System.Data;
using System.Windows.Forms;
using Model;
namespace UI
{
    public partial class ucCategory : UserControl
    {
        DataGridView grid; TextBox name, description, notes; int editId;
        public ucCategory() { InitializeComponent(); Build(); RefreshList(); }
        void Build()
        {
            var panel = UiToolkit.Layout(this, "Category Database", 120);
            var bar = UiToolkit.Bar(); panel.Controls.Add(bar,0,1);
            name=UiToolkit.Text(bar,"Category Name",155);
            description=UiToolkit.Text(bar,"Description",180);
            notes=UiToolkit.Text(bar,"Notes",150);
            UiToolkit.Button(bar,"Save Category", Save);
            UiToolkit.Button(bar,"Edit Selected",Edit);
            UiToolkit.Button(bar,"Clear",Clear);
            UiToolkit.Button(bar,"Refresh", RefreshList);
            grid=UiToolkit.Grid(); panel.Controls.Add(grid,0,2);
        }
        void RefreshList() { grid.DataSource=AppServices.Categories.GetAll(); }
        void Edit()
        {
            var r=UiToolkit.Selected(grid); editId=UiToolkit.Id(r);
            name.Text=UiToolkit.Str(r,"Name"); description.Text=UiToolkit.Str(r,"Description"); notes.Text=UiToolkit.Str(r,"Notes");
        }
        void Clear() { editId=0; name.Clear(); description.Clear(); notes.Clear(); grid.ClearSelection(); }
        void Save()
        {
            var c = new Category { Id=editId, Name=name.Text.Trim(), Description=description.Text.Trim(), Notes=notes.Text.Trim() };
            if(editId==0) AppServices.Categories.Add(c); else AppServices.Categories.Update(c);
            RefreshList(); Clear(); UiToolkit.Info("Category saved successfully.");
        }
    }
}
