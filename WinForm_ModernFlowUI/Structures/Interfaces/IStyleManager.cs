
namespace ModernUI.Structures.Interfaces
{
    public interface IStyleManager
    {
        System.Drawing.Color MdiParentBackColor { get; set; }
        System.Drawing.Color TitleBarForeColor { get; set; }
        System.Drawing.Color TitleBarBackColor { get; set; }
        System.Drawing.Color BackColor { get; set; }
        System.Drawing.Color ForeColor { get; set; }
        ModernUI.Structures.Style.DefaultStyle.Buttons ButtonStyle { get; set; }
    }
}
