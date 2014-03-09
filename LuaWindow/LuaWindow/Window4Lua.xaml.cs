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
using System.Windows.Shapes;

namespace LuaWindow
{
    /// <summary>
    /// Window4Lua.xaml の相互作用ロジック
    /// </summary>
    public partial class Window4Lua : Window
    {
        /// <summary>
        /// ウィンドウを作る
        /// </summary>
        /// <returns></returns>
        public static Window4Lua CreateWindow4Lua()
        {
            return new Window4Lua();
        }

        private Dictionary<string, FrameworkElement> childElements;


        /// <summary>
        /// メッセージボックスを表示
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
        }

        /// <summary>
        /// コントロールを配置
        /// </summary>
        /// <param name="name">コントロール名</param>
        /// <param name="element">登録コントロール</param>
        /// <param name="left">左座標</param>
        /// <param name="top">上座標</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        private void setElementLayout(string name, FrameworkElement element, int left, int top, int width, int height)
        {
            element.Width = width;
            element.Height = height;
            Canvas.SetLeft(element, left);
            Canvas.SetTop(element, top);

            CanvasLayout.Children.Add(element);

            childElements.Add(name, element);
        }

        /// <summary>
        /// ボタンを追加
        /// </summary>
        /// <param name="name">ボタン名</param>
        /// <param name="content">表示</param>
        /// <param name="left">左座標</param>
        /// <param name="top">上座標</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="handler">クリックイベントハンドラ</param>
        public void AddButton(string name, string content, int left, int top, int width, int height,
            RoutedEventHandler handler = null)
        {
            if (childElements.ContainsKey(name)) return;

            var btn = new Button() {Content = content};

            if(handler != null) btn.Click += handler;

            setElementLayout(name, btn, left, top, width, height);
        }

        /// <summary>
        /// テキストボックスを追加
        /// </summary>
        /// <param name="name">テキストボックス名</param>
        /// <param name="defaultValue">初期文字列</param>
        /// <param name="left">左座標</param>
        /// <param name="top">上座標</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        public void AddTextBox(string name, string defaultValue, int left, int top, int width, int height)
        {
            if (childElements.ContainsKey(name)) return;

            var textBox = new TextBox();

            textBox.Text = defaultValue;

            setElementLayout(name, textBox, left, top, width, height);
        }

        /// <summary>
        /// コントロール取得
        /// </summary>
        /// <typeparam name="T">コントロールタイプ</typeparam>
        /// <param name="name">コントロール名</param>
        /// <returns></returns>
        private T GetElement<T>(string name) where T : FrameworkElement
        {
            if (!childElements.ContainsKey(name)) return null;

            var element = childElements[name];

            if (!(element is T)) return null;

            return element as T;
        }

        /// <summary>
        /// ボタン取得
        /// </summary>
        /// <param name="name">ボタン名</param>
        /// <returns>取得したボタン</returns>
        public Button GetButton(string name)
        {
            return GetElement<Button>(name);
        }

        /// <summary>
        /// テキストボックス取得
        /// </summary>
        /// <param name="name">テキストボックス名</param>
        /// <returns>取得したテキストボックス</returns>
        public TextBox GetTextBox(string name)
        {
            return GetElement<TextBox>(name);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Window4Lua()
        {
            InitializeComponent();

            childElements = new Dictionary<string, FrameworkElement>();
        }
    }
}
