using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Collections;

using System.Web;

namespace dolquest
{
    // file field
    enum FILEDATA : int
    {
        Q_ID,
        Q_NAME,
        Q_DIFF,
        Q_CRONO,
        Q_TYPE,
        Q_CITY,
        Q_SKILLS,
        Q_DISC_TYPE,
        Q_DISC_NAME,
        Q_ITEM,
        Q_MEMO,
        Q_LASTUPDATE,
        Q_CONT_NAME,
        Q_CONT_SEQ,
        Q_PREV_NO,
        Q_FOLL_NO
    }

    // grid field
    enum GRIDDATA : int
    {
        G_CLREA
    , G_CARD
    , G_ID
    , G_NAME
    , G_DIFF
    , G_TYPE
    , G_CITY
    , G_SKILL1
    , G_SKILL1R
    , G_SKILL2
    , G_SKILL2R
    , G_SKILL3
    , G_SKILL3R
    , G_DISC_TYPE
    , G_DISC_NAME
    , G_PREV_NO
    , G_FOLL_NO
    , G_CONT_NAME
    , G_CONT_SEQ
    , G_CRONO
    }



    public partial class MainWindow : Form
    {

        int diffwidth = 0;
        int diffheight = 0;

        int minHeight = 0;
        int minWidth = 0;

        DataSet questData;
        Hashtable userData;

        BindingSource bs;

        SortedSet<string> city;
        HashSet<string> skill;
        SortedSet<string> crono;
        SortedSet<string> guild;
        SortedSet<string> contq;

        SortedSet<string> disctype;

        Hashtable disctype_totalcount;
        Hashtable disctype_clearcount;
        Hashtable disctype_cardcount;

        int contextId = 0;
        int contextRownum = 0;

        public MainWindow()
        {
            InitializeComponent();

            this.Text = StaticCode.APP_NAME;

            // 検索条件の未選択を追加しておく　＆　YES/NOは入れておく

            cmbFin.Items.Add("");
            cmbFin.Items.Add(StaticCode.CLEAR_TRUE);
            cmbFin.Items.Add(StaticCode.CLEAR_FALSE);

            cmbCard.Items.Add("");
            cmbCard.Items.Add(StaticCode.CARD_TRUE);
            cmbCard.Items.Add(StaticCode.CARD_FALSE);

            city = new SortedSet<string>(); city.Add("");
            skill = new HashSet<string>(); skill.Add("");
            crono = new SortedSet<string>(); crono.Add("");
            guild = new SortedSet<string>(); guild.Add("");
            contq = new SortedSet<string>(); contq.Add("");

            disctype = new SortedSet<string>(); disctype.Add("");

            // skillは指定された学問のみ
            string learn = ConfigurationManager.AppSettings[StaticCode.APP_KEY_DISC_SKILL];
            string[] learns = learn.Split(',');
            foreach (string str in learns)
            {
                skill.Add(str);
            }

            // 件数テーブル初期化
            disctype_clearcount = new Hashtable();
            disctype_cardcount = new Hashtable();
            disctype_totalcount = new Hashtable();

            // ユーザデータテーブル初期化
            userData = new Hashtable();

            // クエストデータテーブル初期化
            questData = new DataSet(StaticCode.DATASET_NAME);
            bs = new BindingSource();

            // クエストデータのカラム設定
            DataTable dataTable = questData.Tables.Add(StaticCode.DATATABLE_NAME);
            DataColumn dataClumn00 = dataTable.Columns.Add("発見", typeof(Boolean));
            DataColumn dataClumn01 = dataTable.Columns.Add("カード", typeof(Boolean));
            DataColumn dataClumn02 = dataTable.Columns.Add("ID", typeof(int));
            DataColumn dataClumn03 = dataTable.Columns.Add("クエスト名");
            DataColumn dataClumn04 = dataTable.Columns.Add("★");
            DataColumn dataClumn06 = dataTable.Columns.Add("ギルド");
            DataColumn dataClumn07 = dataTable.Columns.Add("都市");
            DataColumn dataClumn08 = dataTable.Columns.Add("スキル1");
            DataColumn dataClumn08R = dataTable.Columns.Add("1R", typeof(int));
            DataColumn dataClumn09 = dataTable.Columns.Add("スキル2");
            DataColumn dataClumn09R = dataTable.Columns.Add("2R", typeof(int));
            DataColumn dataClumn10 = dataTable.Columns.Add("スキル3");
            DataColumn dataClumn10R = dataTable.Columns.Add("3R", typeof(int));
            DataColumn dataClumn11 = dataTable.Columns.Add("種類");
            DataColumn dataClumn12 = dataTable.Columns.Add("発見物");
            DataColumn dataClumn13 = dataTable.Columns.Add("前提");
            DataColumn dataClumn14 = dataTable.Columns.Add("後続");
            DataColumn dataClumn15 = dataTable.Columns.Add("連続クエスト");
            DataColumn dataClumn16 = dataTable.Columns.Add("順番");
            DataColumn dataClumn05 = dataTable.Columns.Add("クロノ");
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };

            // フォームの大きさを保存しておく
            diffwidth = this.Width - this.tabView.Width;
            diffheight = this.Height - this.tabView.Height;

            minWidth = this.Width;
            minHeight = this.Height;

            // ファイルロード
            loadData();

            // データの表示
            showNewData(questData);

        }


        // フォームリサイズの適用
        private void MainWindow_Resize(object sender, EventArgs e)
        {
//            Console.WriteLine("{0}, {1}", this.Width, minWidth);
//            Console.WriteLine("{0}, {1}", this.Height, minHeight);

            if (this.WindowState != FormWindowState.Minimized)
            {

                if (this.Width < minWidth)
                {
                    this.Width = minWidth;
                }
                if (this.Height < minHeight)
                {
                    this.Height = minHeight;
                }

                this.tabView.Width = this.Size.Width - diffwidth;
                this.tabView.Height = this.Size.Height - diffheight;
            }
       
        }

        // グリッドのフォーマット
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView g = (DataGridView)sender;
            // クリアしてるのはグレーにする
            if (g != null)
            {
                int col = e.ColumnIndex;
                int row = e.RowIndex;

                if ((bool)g[(int)GRIDDATA.G_CLREA, row].Value) {
                    if ((bool)g[(int)GRIDDATA.G_CARD, row].Value)
                    {
                        e.CellStyle.BackColor = Color.Gray;
                    } else
                    {
                        if ((string)g[(int)GRIDDATA.G_DISC_TYPE, row].Value == "")
                        {   //発見物無し
                            e.CellStyle.BackColor = Color.Gray;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.LightGray;
                        }
                    }
                } else
                {
                    if ((bool)g[(int)GRIDDATA.G_CARD, row].Value)
                    {
                        e.CellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                }


            }

        }

        // データのロード
        private void loadData()
        {
            string loadFilePath = Application.StartupPath + StaticCode.QUEST_FILE_NAME;

            DataSet newDataSet = questData.Clone();

            disctype_totalcount.Clear();

            // ファイルチェック
            if (!System.IO.File.Exists(loadFilePath))
            {
                MessageBox.Show("クエストデータファイルが存在しません。");
                return;
            }
  
            System.IO.StreamReader sr = new System.IO.StreamReader(
                    loadFilePath,
                    System.Text.Encoding.GetEncoding("shift_jis"));
            sr.ReadLine();
            //一行ずつ読み込む
            while (sr.Peek() > -1)
            {
                string linedata = sr.ReadLine();
                string[] data = linedata.Split('\t');

                // スキル スプリットする
                string[] skills = data[(int)FILEDATA.Q_SKILLS].Split(',');
                string skill1 = "";
                string skill1r = "";
                string skill2 = "";
                string skill2r = "";
                string skill3 = "";
                string skill3r = "";
                if (skills.Length > 0)
                {
                    string[] tmp = skills[0].Trim().Split('(');
                    skill1 = tmp[0].Trim();
                    if (tmp.Length > 1) { skill1r = tmp[1].Replace(")", ""); }
                }
                if (skills.Length > 1)
                {
                    string[] tmp = skills[1].Trim().Split('(');
                    skill2 = tmp[0].Trim();
                    if (tmp.Length > 1) { skill2r = tmp[1].Replace(")", ""); }
                }
                if (skills.Length > 2)
                {
                    string[] tmp = skills[2].Trim().Split('(');
                    skill3 = tmp[0].Trim();
                    if (tmp.Length > 1) { skill3r = tmp[1].Replace(")", ""); }
                }

                // 地図
                if (data[(int)FILEDATA.Q_TYPE] != "")
                {
                    if (isLearn(data[(int)FILEDATA.Q_TYPE]))
                    {
                        string learn = data[(int)FILEDATA.Q_TYPE];
                        if (learn != skill1 && learn != skill2 && learn != skill3) {
                            if (skill1 == "") { skill1 = data[(int)FILEDATA.Q_TYPE]; skill1r = data[(int)FILEDATA.Q_DIFF]; }
                            else if (skill2 == "") { skill2 = data[(int)FILEDATA.Q_TYPE]; skill2r = data[(int)FILEDATA.Q_DIFF]; }
                            else if (skill3 == "") { skill3 = data[(int)FILEDATA.Q_TYPE]; skill3r = data[(int)FILEDATA.Q_DIFF]; }
                        }
                        data[(int)FILEDATA.Q_TYPE] = StaticCode.GUILD_MAP;
                    }
                }

                //発見物のない地図は無視
                if (data[(int)FILEDATA.Q_DISC_NAME]=="" && data[(int)FILEDATA.Q_TYPE]== StaticCode.GUILD_MAP)
                {
                    continue;
                }

                    // データセットに保存
                    newDataSet.Tables[StaticCode.DATATABLE_NAME].Rows.Add(new Object[] {
                                             false
                                            ,false
                                            ,data[(int)FILEDATA.Q_ID]
                                            ,data[(int)FILEDATA.Q_NAME]
                                            ,data[(int)FILEDATA.Q_DIFF]
                                            ,data[(int)FILEDATA.Q_TYPE]
                                            ,data[(int)FILEDATA.Q_CITY]
                                            ,skill1
                                            ,skill1r!=""? int.Parse(skill1r) : 0
                                            ,skill2
                                            ,skill2r != "" ? int.Parse(skill2r) : 0
                                            ,skill3
                                            ,skill3r!="" ? int.Parse(skill3r) : 0
                                            ,data[(int)FILEDATA.Q_DISC_TYPE]
                                            ,data[(int)FILEDATA.Q_DISC_NAME]
                                            ,data[(int)FILEDATA.Q_PREV_NO]
                                            ,data[(int)FILEDATA.Q_FOLL_NO]
                                            ,data[(int)FILEDATA.Q_CONT_NAME]
                                            ,data[(int)FILEDATA.Q_CONT_SEQ]
                                            ,data[(int)FILEDATA.Q_CRONO]
                                           }
                                );
                // 都市
                if (data[(int)FILEDATA.Q_CITY] != "")
                {
                    string[] cities = data[(int)FILEDATA.Q_CITY].Split(',');
                    foreach (string citydat in cities)
                    {
                        city.Add(citydat.Trim());
                    }
                }
                // クロノ
                if (data[(int)FILEDATA.Q_CRONO] != "")
                {
                    crono.Add(data[(int)FILEDATA.Q_CRONO].Trim());
                }
                // ギルド
                if (data[(int)FILEDATA.Q_TYPE] != "")
                {
                        guild.Add(data[(int)FILEDATA.Q_TYPE].Trim());
                }
                // 連続クエスト
                if (data[(int)FILEDATA.Q_CONT_NAME] != "")
                {
                    contq.Add(data[(int)FILEDATA.Q_CONT_NAME].Trim());
                }
                // 発見物種別
                if (data[(int)FILEDATA.Q_DISC_TYPE] != "")
                {
                    disctype.Add(data[(int)FILEDATA.Q_DISC_TYPE].Trim());
                }

                // カウント 発見物アリ、勅命ではない
                if (data[(int)FILEDATA.Q_DISC_TYPE] != "" && data[(int)FILEDATA.Q_TYPE]!="勅命クエスト")
                {
                    if (disctype_totalcount[data[(int)FILEDATA.Q_DISC_TYPE]] == null)
                    {
                        disctype_totalcount[data[(int)FILEDATA.Q_DISC_TYPE]] = 1;
                    }
                    else
                    {
                        disctype_totalcount[data[(int)FILEDATA.Q_DISC_TYPE]] = (int)disctype_totalcount[data[(int)FILEDATA.Q_DISC_TYPE]] + 1;
                    }
                }

            }
            //閉じる
            sr.Close();
            // データセットのコピー
            questData.Clear();
            questData = newDataSet.Copy();

            // ユーザデータのロード
            loadUserData();

        }

        private bool isLearn(string str) {
            // skillは指定された学問のみ
            string learn = ConfigurationManager.AppSettings[StaticCode.APP_KEY_DISC_SKILL];
            string[] learns = learn.Split(',');
            foreach (string tmp in learns)
            {
                if (tmp==str)
                {
                    return true;
                }
            }
            return false;
        }


        void showNewData(DataSet gridData)
        {
            // 表示
            bs.DataSource = gridData.Tables[0];
            dataGridView.DataSource = bs;

            // カラムの幅設定
            dataGridView.Columns[(int)GRIDDATA.G_CLREA].Width = 40;
            dataGridView.Columns[(int)GRIDDATA.G_CARD].Width = 40;
            dataGridView.Columns[(int)GRIDDATA.G_ID].Width = 50;
            dataGridView.Columns[(int)GRIDDATA.G_NAME].Width = 150;
            dataGridView.Columns[(int)GRIDDATA.G_DIFF].Width = 25;
            dataGridView.Columns[(int)GRIDDATA.G_CRONO].Width = 75;
            dataGridView.Columns[(int)GRIDDATA.G_TYPE].Width = 150;
            dataGridView.Columns[(int)GRIDDATA.G_CITY].Width = 150;
            dataGridView.Columns[(int)GRIDDATA.G_SKILL1].Width = 65;
            dataGridView.Columns[(int)GRIDDATA.G_SKILL1R].Width = 25;
            dataGridView.Columns[(int)GRIDDATA.G_SKILL2].Width = 65;
            dataGridView.Columns[(int)GRIDDATA.G_SKILL2R].Width = 25;
            dataGridView.Columns[(int)GRIDDATA.G_SKILL3].Width = 65;
            dataGridView.Columns[(int)GRIDDATA.G_SKILL3R].Width = 25;
            dataGridView.Columns[(int)GRIDDATA.G_DISC_TYPE].Width = 65;
            dataGridView.Columns[(int)GRIDDATA.G_DISC_NAME].Width = 150;
            dataGridView.Columns[(int)GRIDDATA.G_PREV_NO].Width = 150;
            dataGridView.Columns[(int)GRIDDATA.G_FOLL_NO].Width = 150;
            dataGridView.Columns[(int)GRIDDATA.G_CONT_NAME].Width = 150;
            dataGridView.Columns[(int)GRIDDATA.G_CONT_SEQ].Width = 55;

            // ヘッダの文言変更
            dataGridView.Columns[(int)GRIDDATA.G_SKILL1R].HeaderText = "R";
            dataGridView.Columns[(int)GRIDDATA.G_SKILL2R].HeaderText = "R";
            dataGridView.Columns[(int)GRIDDATA.G_SKILL3R].HeaderText = "R";

            // 複数選択できないようにする
            dataGridView.MultiSelect = false;

            // ID順ソートにする
            dataGridView.Sort(dataGridView.Columns[(int)GRIDDATA.G_ID], ListSortDirection.Ascending);

            // 検索条件のアップデート処理
            updateComboData(this.cmbCity, city);
            updateComboData(this.cmbCrono, crono);
            updateComboData(this.cmbSkill, skill);
            updateComboData(this.cmbContq, contq);
            updateComboData(this.cmbType, guild);
            updateComboData(this.cmbDiscType, disctype);

            search();

        }

        // 検索条件のcomboボックスのデータ更新（SortedSet）
        private void updateComboData(ComboBox cmb, SortedSet<string> set)
        {
            cmb.Items.Clear();
            cmb.BeginUpdate();
            foreach (string data in  set)
            {
                cmb.Items.Add(data);
            }
            cmb.EndUpdate();
        }

        // 検索条件のcomboボックスのデータ更新（HashSet）
        private void updateComboData(ComboBox cmb, HashSet<string> set)
        {
            cmb.Items.Clear();
            cmb.BeginUpdate();
            foreach (string data in set)
            {
                cmb.Items.Add(data);
            }
            cmb.EndUpdate();
        }
        
        // 検索ボタン
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        // 検索処理
        private void search() 
        {
            // 検索条件取得
            string qSkill = cmbSkill.Text;
            string qCity = cmbCity.Text;
            string qType = cmbType.Text;
            string qCrono = cmbCrono.Text;

            string qContq = cmbContq.Text;

            string qFin = cmbFin.Text;
            string qCard = cmbCard.Text;

            string qDiscType = cmbDiscType.Text;

            bool qUnvisMQ = chkUnvisibleMQ.Checked;
            bool qUnvisFQ = chkUnvisibleFQ.Checked;
            bool qUnvisCQ = chkUnvisibleCQ.Checked;

            string qText = txtFreeword.Text;

            List<string> filterlist = new List<string>();

            // コンボボックス
            if (qSkill != "")
            {
                string tmp = string.Format("(スキル1 = '{0:s}' OR スキル2 = '{0:s}' OR スキル3 = '{0:s}') ", qSkill, qSkill, qSkill);
                filterlist.Add(tmp);
            }
            if (qCity != "")
            {
                string tmp = string.Format("(都市 like '%{0:s}%' )", qCity);
                filterlist.Add(tmp);
            }
            if (qType != "")
            {
                string tmp = string.Format("(ギルド = '{0:s}' )", qType);
                filterlist.Add(tmp);
            }
            if (qCrono != "")
            {
                string tmp =  string.Format("(クロノ = '{0:s}' )", qCrono);
                filterlist.Add(tmp);
            }
            if (qContq != "")
            {
                string tmp = string.Format("(連続クエスト = '{0:s}' )", qContq);
                filterlist.Add(tmp);
            }
            if (qDiscType != "")
            {
                string tmp = string.Format("(種類 = '{0:s}' )", qDiscType);
                filterlist.Add(tmp);
            }
            if (qFin == StaticCode.CLEAR_TRUE)
            {
                string tmp = "発見 = true";
                filterlist.Add(tmp);
            }
            if (qFin == StaticCode.CLEAR_FALSE)
            {
                string tmp = "発見 = false";
                filterlist.Add(tmp);
            }
            if (qCard == StaticCode.CARD_TRUE)
            {
                string tmp = "カード = true";
                filterlist.Add(tmp);
            }
            if (qCard == StaticCode.CARD_FALSE)
            {
                string tmp = "カード = false";
                filterlist.Add(tmp);
            }
            // 非表示チェック
            if (qUnvisMQ)
            {
                string tmp = "not(ギルド='交易クエスト')";
                filterlist.Add(tmp);
            }
            if (qUnvisFQ)
            {
                string tmp = "not(ギルド='海事クエスト')";
                filterlist.Add(tmp);
            }
            if (qUnvisCQ)
            {
                string tmp = "not(ギルド='勅命クエスト')";
                filterlist.Add(tmp);
            }

            // フリーワード→クエスト名
            List<string> freelist = new List<string>();
            if (qText != "")
            {
                string tmp = "";

                tmp = string.Format("(発見物 like '%{0:s}%' )", qText);
                freelist.Add(tmp);
                tmp = string.Format("(クエスト名 like '%{0:s}%' )", qText);
                freelist.Add(tmp);

            }

            // フィルタの構築
            string strFilter = "";
            // フリーワード
            foreach (string data in freelist)
            {
                if (strFilter != "")
                {
                    strFilter = strFilter + " OR ";
                }
                strFilter = strFilter + " " + data + " ";
            }
            if (strFilter !="") { strFilter = " ( " + strFilter + " ) "; }
            // 個別項目
            foreach ( string data in filterlist)
            {
                if (strFilter != "")
                {
                    strFilter = strFilter + " AND ";
                }
                strFilter = strFilter + " " + data + " ";
            }

            updateStatusCount(strFilter);

            this.tabView.SelectedIndex = 1;

        }

        // ステータスバーの件数表示
        private void updateStatusCount(string strFilter)
        {
            string tmpClear = "";
            string tmpDiscover = "";
            string tmpCard = "";
            if (strFilter != "")
            {
                tmpClear = strFilter + " and ";
                tmpDiscover = strFilter + " and ";
                tmpCard = strFilter + " and ";
            }
            tmpClear = tmpClear + " (発見 = true) ";
            tmpDiscover = tmpDiscover + " (発見 = true) and (種類<>'') ";
            tmpCard = tmpCard + " (カード = true)  and (種類<>'') ";

            BindingSource bsTmp = bs;
            bsTmp.Filter = tmpClear;
            int clearCount = bsTmp.Count;
            bsTmp.Filter = tmpDiscover;
            int discoverCount = bsTmp.Count;
            bsTmp.Filter = tmpCard;
            int cardCount = bsTmp.Count;

            // フィルタ
            bs.Filter = strFilter;
            int rowCount = bs.Count;

            // 件数表示
            toolStripStatusLabel.Text = "総件数:" + rowCount + "件/クリア:" + clearCount  + "/発見:" + discoverCount + "件/カード:" + cardCount + "件";
            this.tabView.SelectedIndex = 1;
        }


        // クエストデータ更新ボタン
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateQuestData();
        }

        // クエストデータのダウンロード更新
        private void updateQuestData()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("ネットワークに接続されていません。", StaticCode.APP_NAME);
            }
            else
            {

                string datafilename = Application.StartupPath + StaticCode.QUEST_FILE_NAME;
                string questurl = ConfigurationManager.AppSettings[StaticCode.APP_KEY_QUEST_DATA_URL];

                Microsoft.VisualBasic.Devices.Network network =
                    new Microsoft.VisualBasic.Devices.Network();
                network.DownloadFile(
                questurl, datafilename,
                "", "",
                true, 6000, true,
                Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            }

            loadData();
            showNewData(questData);
            bs.Filter = "";
            toolStripStatusLabel.Text = bs.Count + "件";

        }


        // クリア＆カードのチェック ON/OFF
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            if (g != null)
            {
                int col = e.ColumnIndex;
                int row = e.RowIndex;
                if (row < 0) { return; }

                int id = (int)g[(int)GRIDDATA.G_ID, row].Value;
                if (col == (int)GRIDDATA.G_CLREA || col == (int)GRIDDATA.G_CARD)
                {
                    g[col, row].Value = (bool)g[col, row].Value ? false : true;

                    string clearFlg = (bool)g[(int)GRIDDATA.G_CLREA, row].Value ? StaticCode.CHK_TRUE : StaticCode.CHK_FALSE;
                    string cardFlg = (bool)g[(int)GRIDDATA.G_CARD, row].Value ? StaticCode.CHK_TRUE : StaticCode.CHK_FALSE;

                    userData[id] = clearFlg + cardFlg;

                    saveUserData();

                    string disctype = (string)g[(int)GRIDDATA.G_DISC_TYPE,row].Value;

                }

            }
        }

        // ユーザーデータのロード
        private void loadUserData()
        {
            string userfile = Application.StartupPath + StaticCode.USER_FILE_NAME;

            if (userData == null)          { userData = new Hashtable();            }
            if (disctype_clearcount==null) { disctype_clearcount = new Hashtable();            }
            if (disctype_cardcount==null)  { disctype_cardcount = new Hashtable();            }

            // ファイルチェック
            userData.Clear();
            disctype_clearcount.Clear();
            disctype_cardcount.Clear();
            if (!System.IO.File.Exists(userfile))
            {
                return;
            }

            System.IO.StreamReader sr = new System.IO.StreamReader(
                    userfile,
                    System.Text.Encoding.GetEncoding("shift_jis"));
            //一行ずつ読み込む
            while (sr.Peek() > -1)
            {
                string linedata = sr.ReadLine();
                string[] data = linedata.Split('\t');

                string id = data[0];
                string datas = data[1];

                string clearFlg = datas.Substring(0,1);
                string cardFlg = datas.Substring(1, 1);

                DataRow targetRow = questData.Tables[StaticCode.DATATABLE_NAME].Rows.Find(id);
                targetRow[(int)GRIDDATA.G_CLREA] = clearFlg == StaticCode.CHK_TRUE ? true : false;
                targetRow[(int)GRIDDATA.G_CARD] = cardFlg == StaticCode.CHK_TRUE ? true : false;

                string rowDiscType = (string)targetRow[(int)GRIDDATA.G_DISC_TYPE];

                if (rowDiscType != "")
                {
                    bool rowClear = (bool)targetRow[(int)GRIDDATA.G_CLREA];
                    bool rowCard = (bool)targetRow[(int)GRIDDATA.G_CARD];
                    // clear
                    if (disctype_clearcount[rowDiscType] == null)
                    {
                        disctype_clearcount[rowDiscType] = rowClear ? 1 : 0;
                    }
                    else
                    {
                        disctype_clearcount[rowDiscType] = (int)disctype_clearcount[rowDiscType] + (rowClear ? 1 : 0);
                    }
                    //card
                    if (disctype_cardcount[rowDiscType] == null)
                    {
                        disctype_cardcount[rowDiscType] = rowCard ? 1 : 0;
                    }
                    else
                    {
                        disctype_cardcount[rowDiscType] = (int)disctype_cardcount[rowDiscType] + (rowCard ? 1 : 0);
                    }
                }

            }
            sr.Close();

            // debug用
            //dumpHashtable(disctype_clearcount);
            //dumpHashtable(disctype_cardcount);
            //dumpHashtable(disctype_totalcount);

            viewCountData();

        }

        // ユーザーデータの保存
        private void saveUserData()
        {
            string userfile = Application.StartupPath + StaticCode.USER_FILE_NAME;

            if (userData == null)
            {
                userData = new Hashtable();
            }

            // 上書きしてしまう
            System.IO.StreamWriter writer = new System.IO.StreamWriter(userfile, false, System.Text.Encoding.GetEncoding("shift_jis"));

            disctype_clearcount.Clear();
            disctype_cardcount.Clear();
            foreach (DataRow row in questData.Tables[StaticCode.DATATABLE_NAME].Rows)
            {
                int rowId = (int)row[(int)GRIDDATA.G_ID];
                bool rowClear = (bool)row[(int)GRIDDATA.G_CLREA];
                bool rowCard = (bool)row[(int)GRIDDATA.G_CARD];
                string rowDiscType = (string)row[(int)GRIDDATA.G_DISC_TYPE];

                string tmpClear = rowClear ? StaticCode.CHK_TRUE : StaticCode.CHK_FALSE;
                string tmpCard = rowCard ? StaticCode.CHK_TRUE : StaticCode.CHK_FALSE;
                string tmpFlg = tmpClear + tmpCard;
                // クリアかカードのどちらかがあるときだけ保存
                if (tmpFlg != StaticCode.CHK_FALSE+ StaticCode.CHK_FALSE) {
                    writer.WriteLine(rowId + "\t" + tmpFlg);
                    if (rowDiscType != "")
                    {
                        // clear
                        if (disctype_clearcount[rowDiscType] == null)
                        {
                            disctype_clearcount[rowDiscType] = rowClear ? 1 : 0;
                        }
                        else
                        {
                            disctype_clearcount[rowDiscType] = (int)disctype_clearcount[rowDiscType] + (rowClear ? 1 : 0);
                        }
                        //card
                        if (disctype_cardcount[rowDiscType] == null)
                        {
                            disctype_cardcount[rowDiscType] = rowCard ? 1 : 0;
                        }
                        else
                        {
                            disctype_cardcount[rowDiscType] = (int)disctype_cardcount[rowDiscType] + (rowCard ? 1 : 0);
                        }
                    }
                };
            }
            writer.Close();

            // debug用
            //dumpHashtable(disctype_clearcount);
            //dumpHashtable(disctype_cardcount);
            //dumpHashtable(disctype_totalcount);

            viewCountData();

        }

        // debug用
        private void dumpHashtable(Hashtable hashtable) {
            Console.WriteLine("----");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }
        }

        private void viewCountData()
        {
            ArrayList keys = new ArrayList(disctype_totalcount.Keys);
            keys.Sort();
            foreach (string key in keys)
            {
                int total = disctype_totalcount[key] != null ? (int)disctype_totalcount[key] : 0;
                int clear = disctype_clearcount[key] != null ? (int)disctype_clearcount[key] : 0;
                int card = disctype_cardcount[key] != null ? (int)disctype_cardcount[key] : 0;

                Console.WriteLine( String.Format("{0}:{1}/{2}/{3}",key,total, clear, card) );
            }
        }

        // コンテキストメニュー
        private void dataGridView_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int rownum = e.RowIndex;    // クリックした行のインデックス

            if (dgv!=null)
            {
                // 選択状態にする
                dgv.Rows[rownum].Selected = true;

                // クリックした行のデータ
                int id = (int)dgv[(int)GRIDDATA.G_ID, rownum].Value;
                string prev = (string)dgv[(int)GRIDDATA.G_PREV_NO, rownum].Value;
                string foll = (string)dgv[(int)GRIDDATA.G_FOLL_NO, rownum].Value;

                contextId = id;
                contextRownum = rownum;

                // 前提のクエストリスト
                ArrayList prevList = getQuestList(prev);
                // 後続のクエストリスト
                ArrayList follList = getQuestList(foll);

                // コンテキストメニューの子供にクエストを追加
                ToolStripMenuItem mPrev = (ToolStripMenuItem)contextMenuStrip.Items[0];
                mPrev.DropDownItems.Clear();
                if (prevList!=null)
                {
                    foreach (string[] dat in prevList)
                    {
                        string tmp = "";
                        if (isQuestClear(dat[0]))
                        {
                            tmp = StaticCode.QUEST_CLEAR  + dat[1];
                        } else
                        {
                            tmp = StaticCode.QUEST_NOCLR  + dat[1];
                        }
                        mPrev.DropDownItems.Add(tmp, null, questToolStripMenuItem_Click);
                    }
                }

                ToolStripMenuItem mFoll = (ToolStripMenuItem)contextMenuStrip.Items[1];
                mFoll.DropDownItems.Clear();
                if (follList != null)
                {
                    foreach (string[] dat in follList)
                    {
                        string tmp = "";
                        if (isQuestClear(dat[0]))
                        {
                            tmp = StaticCode.QUEST_CLEAR + dat[1];
                        }
                        else
                        {
                            tmp = StaticCode.QUEST_NOCLR + dat[1];
                        }
                        mFoll.DropDownItems.Add(tmp, null, questToolStripMenuItem_Click);
                    }
                }
            }
        }

        // 前提、後続のクエストデータをリストに変換
        private ArrayList getQuestList(string str)
        {
            if (str=="") { return null; }
            ArrayList list = new ArrayList();
            string[] data = str.Split(',');
            foreach (string tmp in data)
            {
                string[] dat = tmp.Split(':');
                list.Add(dat);
            }
            return list;
        }

        // クエストIDで、クエストクリアしているかチェック
        private bool isQuestClear(string id)
        {
            DataRow targetRow = questData.Tables[StaticCode.DATATABLE_NAME].Rows.Find(id);
            if (targetRow != null)
            {
                return (bool)targetRow[(int)GRIDDATA.G_CLREA];
            } else
            {
                return false;
            }
        }

        // 右クリック→前提/後続
        private void questToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string qName = item.Text.Replace(StaticCode.QUEST_CLEAR,"").Replace(StaticCode.QUEST_NOCLR,"");
            clearSearchCond();
            txtFreeword.Text = qName;
            search();
        }


        // 右クリック→Google検索
        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // URL作成
            DataGridView dgv = this.dataGridView;
            string qname = (string)dgv[(int)GRIDDATA.G_NAME, contextRownum].Value;
            string urlParam = HttpUtility.UrlEncode(qname);
            string url = string.Format("https://www.google.co.jp/?gws_rd=ssl#q={0:s}", urlParam);
            System.Diagnostics.Process.Start(url);
        }

        // 右クリック→大航海時代データベース
        private void dDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = string.Format(ConfigurationManager.AppSettings[StaticCode.APP_KEY_QUEST_WEB_URL], contextId);
            System.Diagnostics.Process.Start(url);
        }

        // 条件クリア
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearSearchCond();
        }
        private void clearSearchCond()
        {
            cmbCard.SelectedIndex = 0;
            cmbFin.SelectedIndex = 0;
            cmbSkill.SelectedIndex = 0;
            cmbCity.SelectedIndex = 0;
            cmbCrono.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbContq.SelectedIndex = 0;
            cmbDiscType.SelectedIndex = 0;
            txtFreeword.Text = "";
            chkUnvisibleMQ.Checked = true;
            chkUnvisibleFQ.Checked = true;
            chkUnvisibleCQ.Checked = true;
        }
    }
}
