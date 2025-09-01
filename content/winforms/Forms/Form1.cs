// Visit https://npp-dotnet.github.io/Npp.DotNet.Plugin to learn more.

namespace _ProjectName;

using Npp.DotNet.Plugin;
using Npp.DotNet.Plugin.Winforms;
using Npp.DotNet.Plugin.Winforms.Classes;

#nullable disable warnings
class Form1 : DockingForm
{
    public Form1(int dlgID, string pluginName, Icon frmIcon)
        : base(dlgID, pluginName, FormTitle, null, frmIcon, InitialDockPosition)
    {
        InitializeComponent();
        AttachEventHandlers();
        ToggleDarkMode(PluginData.Notepad.IsDarkModeEnabled());
    }

    /// <inheritdoc cref="FormBase.ToggleDarkMode"/>
    public override void ToggleDarkMode(bool isDark)
    {
        if (isDark)
        {
            DarkMode.DarkModeColors theme = new();
            button1.BackColor = theme.SofterBackground;
            button1.ForeColor = theme.Text;
        }
        else
        {
            button1.BackColor = Color.FromKnownColor(KnownColor.ButtonFace);
            button1.ForeColor = DefaultForeColor;
        }
    }

    /// <inheritdoc cref="FormBase.AttachEventHandlers"/>
    protected override void AttachEventHandlers()
    {
        base.AttachEventHandlers();
        textBox1?.Focus();
    }

    private void Button1Click(object? sender, EventArgs e)
    {
        try
        {
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"https://npp-user-manual.org/docs/plugin-communication/#2036nppm_modelessdialog";
            p.StartInfo.UseShellExecute = true;
            p.Start();
        }
        catch (Exception error)
        {
            MessageBox.Show(
                $"{error.Message}\0",
                $"{error.GetType().Name}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new Button();
        textBox1 = new TextBox();
        SuspendLayout();
        //
        // button1
        //
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        button1.Location = new Point(96, 158);
        button1.Name = "button1";
        button1.Size = new Size(112, 38);
        button1.TabIndex = 1;
        button1.TabStop = true;
        button1.Text = "Learn M&ore";
        button1.UseVisualStyleBackColor = true;
        button1.Click += new EventHandler(Button1Click);
        //
        // textBox1
        //
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        textBox1.Location = new Point(12, 12);
        textBox1.Name = "textBox1";
        textBox1.Multiline = true;
        textBox1.Size = new Size(278, 134);
        textBox1.TabIndex = 0;
        textBox1.TabStop = true;
        textBox1.Text = "1. CTRL+A\r\n2. CTRL+X\r\n3. CTRL+V\r\n\r\nAll working?";
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button1);
        Controls.Add(textBox1);
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private TextBox textBox1;

    static readonly string FormTitle = "Docking Form";
    static readonly NppTbMsg InitialDockPosition = NppTbMsg.DWS_DF_CONT_RIGHT;
}
