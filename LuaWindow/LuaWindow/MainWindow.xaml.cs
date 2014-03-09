using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LuaInterface;

namespace LuaWindow
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var lua = new Lua();

            try
            {
                // ウィンドウ生成処理を関数として登録
                lua.RegisterFunction("CreateWindow", null, typeof(Window4Lua).GetMethod("CreateWindow4Lua"));

                // テキストボックスの処理をLuaとして実行
                lua.DoString(TextLuaCode.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lua Execute Error:\r\n" + ex.Message);
            }
        }
    }
}
