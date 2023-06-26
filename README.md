**Бесилка**

Windows Forms Project by: 
Filip Boshevski

---
1. Опис на апликацијата
	
	Апликацијата што ја развив е класичната игра Бесилка.

	Со цел да се обезбеди комплетно задоволство кај играчот, покрај чистиот и едноставен дизајн, имплементирано се и помошни избори кои им покажуваат на играчот одреден број на букви во зборот.

2. Упатство за користењe

	2.1 Нова игра

	![alt text][new_game_screen]

	На почетниот прозорец (слика 1) при стартување на апликацијата имаме можност да започнеме нова игра **(Започни)**.
	После секој успешно погоден збор, на екранот излегува прозорче кое го известува играчот дека победи со што има можност да започне нова игра.

	2.2 Ресетирај

	![alt text][resetiraj]

	Со помош на оваа фунцкионалност, играчот во секој момент од играта може да ја ресетира со што излегува прозорче кое го известува за постоечката игра и потврдува дека сака вистина да ја ресетира играта.

	2.3 Помош избор

	![alt text][pomos_izbor]

	Доколку корисникот има потешкотии во годењето на зборот, може со помош на копчето **(Помош избор)** да открие една рандом буква од зборот.
	Вкупниот број на помошни избори е 2.

	2.4 Правила
	Правилата се едноставни:

	* Зборот треба да се погоди пред да се нацрта целото човече на бесилката.
	* Бројот на грешни избори е 6, односно, 1 за главата, 1 за телото, 1 за секоја рака и 1 за секоја нога.
	* Бројот на помошни избори е 2, со што играчот може да открие една од буквите во зборот.
* Откако една точна или грешна буква се избере таа не може повторно да се избере.

3. Претставување на проблемот

	3.1 Податочни структури

	Главните податоци и [функции](#3.2-) за играта се чуваат во класа ```public class Scene``` во која се чува состојбата на играта во објект од класата ```public class State``` и состојбата за бесилката во објект од класата ```public class Hanger```.

	```c#
	public class Scene
	{
		private State State { get; set; }

        private Besilka Window { get; set; }

        private Pen HangerPen { get; set; }

        private Pen RopePen { get; set; }

        private Hanger Hanger { get; set; }

        private static string Words = "Бесилка,Здраво,Филтер,Мајмун,Јаже,Кајмак,Сирење,Стол,Лепило,Плоча,Картон,Ножица,Стакло,Компјутер,Ризик,Полнач";

        public Scene(Besilka window)
        {
            Window = window;
            State = new State();
            
            InitializeVars();
            AddButtons();
        }

        private void InitializeVars()
        {
            Hanger = new Hanger();  
            
            HangerPen = new Pen(Color.Black, 20);
            RopePen = new Pen(Color.Black, 7);

            var hangerBottom = new Point(Window.hangerPanel.Width/2 + 70, Window.hangerPanel.Height - 20);
            var hangerTop = new Point(hangerBottom.X, 30);
            var hangerRight = new Point(hangerBottom.X - 10, 40);
            var hangerLeft = new Point(40, hangerRight.Y);

            Hanger.HangerPoints["Top"] = hangerTop;
            Hanger.HangerPoints["Bottom"] = hangerBottom;
            Hanger.HangerPoints["Left"] = hangerLeft;
            Hanger.HangerPoints["Right"] = hangerRight;

            Hanger.Rope = new Point((hangerRight.X + hangerLeft.X) / 3, hangerLeft.Y);
            Hanger.Head = new Point(Hanger.Rope.X - Hanger.HeadDiameter/2, Hanger.Rope.Y + Hanger.RopeLength);
            Hanger.Body = new Point(Hanger.Rope.X, Hanger.Head.Y + Hanger.HeadDiameter);
        }

        public void StartGame()
        {
            if (Window.lettersPanel.Enabled)
                if (MessageBox.Show("Играта е во тек, сакате да започнете одново?", "Игра во тек", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

            ResetControls();
            SelectWord();
            AddLabels();
        }

        private void SelectWord()
        {
            //string filePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Words.txt");
            //using (TextReader tr = new StreamReader(filePath, Encoding.ASCII))
            //{
            //    Random r = new Random();
            //    var allWords = tr.ReadToEnd().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            //    State.Word = allWords[r.Next(0, allWords.Length - 1)];
            //}

            // Mora Words.txt da e sekade kade sto kje bide exe fajlot
            // zatoa hardcoded se words
            var r = new Random();
            var allWords = Words.Split(',');
            State.Word = allWords[r.Next(0, allWords.Length - 1)];
        }

        private void AddLabels()
        {
            Window.gbLetters.Controls.Clear();
            State.Letters.Clear();

            var refer = (Window.gbLetters.Width - 20 * State.Word.Length) / State.Word.Length;

            for (int i = 0; i < State.Word.Length; i++)
            {
                var lbl = new Label
                {
                    Text = State.EmptyChar,
                    Location = new Point(100 + i * refer, Window.gbLetters.Height - 45),
                    Parent = Window.gbLetters,
                    Font = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Regular)
                };

                lbl.BringToFront();
                State.Letters.Add(lbl);
            }

            Window.tbUsedLetters.Text = string.Empty;
            Window.tbRemainingChoices.Text = State.InitialChoicesLeft.ToString();
            Window.tbHelpLeft.Text = State.HelpLeft.ToString();
        }

        private void ResetControls()
        {
            Window.lettersPanel.Controls.Clear();
            AddButtons();
            State.HangState = HangState.None;
            State.HelpLeft = 2;
            Window.hangerPanel.Invalidate();
            Window.tbUsedLetters.Clear();
            Window.lettersPanel.Enabled = true;
            Window.btnHelp.Visible = true;
            Window.btnHelp.Enabled = true;

            Window.btnStartStop.Text = "Ресетирај";

            var menuItem = Window.menuStrip1.Items[0] as ToolStripDropDownItem;
            menuItem.DropDownItems[0].Visible = false;
            menuItem.DropDownItems[1].Visible = true;
            menuItem.DropDownItems[2].Visible = true;
        }

        private void onBtnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var charClicked = button.Text.ToUpper().ToCharArray()[0];
            button.Enabled = false;

            if (State.Word.ToUpper().Contains(charClicked))
            {
                FillChar(charClicked);
            }
            else
            {
                if (State.HangState != HangState.RightLeg) State.HangState++;

                Window.tbRemainingChoices.Text = (Convert.ToInt32(Window.tbRemainingChoices.Text) - 1).ToString();

                Window.hangerPanel.Invalidate();

                if (State.HangState == HangState.RightLeg)
                {
                    Window.lettersPanel.Enabled = false;

                    for (int i = 0; i < State.Word.Length; i++)
                    {
                        if (State.Letters[i].Text.Equals(State.EmptyChar))
                        {
                            State.Letters[i].Text = State.Word.ToUpper()[i].ToString();
                            State.Letters[i].ForeColor = Color.Blue;
                        }
                    }

                    ResetStartButton();
                    MessageBox.Show("Изгубивте. Стартувајте нова игра и обидете се повторно.");
                }
            }

            Window.tbUsedLetters.Text += string.IsNullOrWhiteSpace(Window.tbUsedLetters.Text) ? charClicked.ToString() : "," + charClicked;
        }

        private void FillChar(char charClicked)
        {
            for (int i = 0; i < State.Word.Length; i++)
            {
                if (State.Word.ToUpper()[i].Equals(charClicked))
                    State.Letters[i].Text = charClicked.ToString();
            }

            if (State.Letters.Any(x => x.Text.Equals(State.EmptyChar)))
                return;

            Window.lettersPanel.Enabled = false;
            ResetStartButton();
            MessageBox.Show("Победи. Честито!");
        }

        public void GetHelp()
        {
            if (State.HelpLeft > 0)
            {
                State.HelpLeft--;
                Window.tbHelpLeft.Text = State.HelpLeft.ToString();

                if (State.HelpLeft == 0)
                {
                    Window.btnHelp.Enabled = false;

                    var menuItem = Window.menuStrip1.Items[0] as ToolStripDropDownItem;
                    menuItem.DropDownItems[2].Visible = false;
                }

                var random = new Random();
                var randLetter = random.Next(0, State.Word.Length - 1);
                var letters = State.Letters.Select(l => l.Text).ToList();

                while (letters[randLetter] != State.EmptyChar)
                {
                    randLetter = random.Next(0, State.Word.Length - 1);
                }

                var randChar = State.Word.ToUpper()[randLetter];

                FillChar(randChar);

                Window.tbUsedLetters.Text += string.IsNullOrWhiteSpace(Window.tbUsedLetters.Text) ? randChar.ToString() : "," + randChar;
                Window.lettersPanel.Controls.Find($"btn_{randChar}", false).First().Enabled = false;
            }
        }

        private void ResetStartButton()
        {
            Window.btnStartStop.Text = "Започни";

            var menuItem = Window.menuStrip1.Items[0] as ToolStripDropDownItem;
            menuItem.DropDownItems[0].Visible = true;
            menuItem.DropDownItems[1].Visible = false;
            menuItem.DropDownItems[2].Visible = false;
        }

        /// <summary>
        /// Adds buttons
        /// </summary>
        private void AddButtons()
        {
            var alphabet = "А,Б,В,Г,Д,Ѓ,Е,Ж,З,Ѕ,И,Ј,К,Л,Љ,М,Н,Њ,О,П,Р,С,Т,Ќ,У,Ф,Х,Ц,Ч,Џ,Ш";
            var letters = alphabet.Split(',');

            for (int i = 0; i < letters.Length; i++)
            {
                var btn = new Button
                {
                    Name = $"btn_{letters[i]}",
                    Text = letters[i].ToString(),
                    Font = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold),
                    Size = new Size(40, 40),
                    BackColor = Color.Transparent,
                    Parent = Window.lettersPanel
                };
                btn.Click += onBtnClick;
            }

            Window.lettersPanel.Enabled = false;
        }

        public void Draw(Graphics g)
        {
            InitializeVars();

            if (State.HangState >= HangState.None)
            {
                g.DrawLine(HangerPen, Hanger.HangerPoints["Bottom"], Hanger.HangerPoints["Top"]);
                g.DrawLine(HangerPen, Hanger.HangerPoints["Right"], Hanger.HangerPoints["Left"]);
                g.DrawLine(RopePen, Hanger.Rope, new Point(Hanger.Rope.X, Hanger.Rope.Y + Hanger.RopeLength));
            }

            if (State.HangState >= HangState.Head)
            {
                g.DrawEllipse(RopePen, new Rectangle(new Point(Hanger.Head.X, Hanger.Rope.Y + Hanger.RopeLength), new Size(Hanger.HeadDiameter, Hanger.HeadDiameter)));
            }

            if (State.HangState >= HangState.Body)
            {
                g.DrawLine(RopePen, new Point(Hanger.Rope.X, Hanger.Head.Y + Hanger.HeadDiameter), new Point(Hanger.Rope.X, Hanger.Head.Y + Hanger.HeadDiameter + Hanger.BodyHeight));
            }

            if (State.HangState >= HangState.LeftArm)
            {
                g.DrawLine(RopePen, new Point(Hanger.Rope.X, Hanger.Head.Y + Hanger.HeadDiameter + 20), new Point(Hanger.Rope.X - Hanger.ArmOffset.X, Hanger.Head.Y + Hanger.HeadDiameter + Hanger.ArmOffset.Y));
            }

            if (State.HangState >= HangState.RightArm)
            {
                g.DrawLine(RopePen, new Point(Hanger.Rope.X, Hanger.Head.Y + Hanger.HeadDiameter + 20), new Point(Hanger.Rope.X + Hanger.ArmOffset.X, Hanger.Head.Y + Hanger.HeadDiameter + Hanger.ArmOffset.Y));
            }

            if (State.HangState >= HangState.LeftLeg)
            {
                g.DrawLine(RopePen, new Point(Hanger.Rope.X, Hanger.Head.Y + Hanger.HeadDiameter + Hanger.BodyHeight - 5), new Point(Hanger.Rope.X - Hanger.LegOffset.X, Hanger.Head.Y + Hanger.HeadDiameter + Hanger.BodyHeight + Hanger.LegOffset.Y));
            }

            if (State.HangState >= HangState.RightLeg)
            {
                g.DrawLine(RopePen, new Point(Hanger.Rope.X, Hanger.Head.Y + Hanger.HeadDiameter + Hanger.BodyHeight - 5), new Point(Hanger.Rope.X + Hanger.LegOffset.X, Hanger.Head.Y + Hanger.HeadDiameter + Hanger.BodyHeight + Hanger.LegOffset.Y));
            }
        }
	}
	```

	3.1.1 State
	```c#
		public class State
		{
			public State()
			{
				Letters = new List<Label>();
				HangState = HangState.None;
				HelpLeft = 2;
			}

			public List<Label> Letters { get; set; }

			public string Word { get; set; }

			public string EmptyChar => "__";

			public HangState HangState { get; set; }

			public int InitialChoicesLeft => Enum.GetValues(typeof(HangState)).Length - 1;

			public int HelpLeft { get; set; }
		}
	```
	Со оваа класа ја дефинираме состојбата на играта.

	3.1.2 Hanger
	```c#
		public class Hanger
		{
			public Hanger()
			{
				HangerPoints = new Dictionary<string, Point>();
			}

			public Dictionary<string, Point> HangerPoints { get; set; }

			public Point Rope { get; set; }

			public Point Body { get; set; }

			public Point Head { get; set; }

			public Point LeftArm { get; set; }

			public Point RightArm { get; set; }

			public Point LeftLeg { get; set; }

			public Point RightLeg { get; set; }

			public static int HeadDiameter = 40;

			public static int BodyHeight = 85;

			public static int RopeLength = 40;

			public static Point ArmOffset = new Point(30, 50);

			public static Point LegOffset = new Point(40, 40);
		}
	```
	Со оваа класа ја дефинираме состојбата и клучни податоци за бесилката во играта.

	3.2 Алгоритми

	За да биде различна играта секој пат, имплементирано е рандом генерирање на збор од листа на зборови или текст фајл.

	3.2.1 Почетна состојба
		`StartGame();`
		Со повикување на оваа метода прво се проверува дали веќе постои игра во тек, со што се прикажува прозорче за потврдување на нова игра. 

		Потоа се ресетира состојбата на контролите, се одбира рандом збор од листата и се поставуваат цртичките во играта.

	3.2.2 Кликање на буква
		`onBtnClick();`
		На секое копче-буква се додава Event Handler методата onBtnClick која ја зема буквата на прицнатото копче и проверува дали постои во зборот. 

		Доколку постои, ги наоѓа сите инстанци во цртичките и ги заменува со буквата. 

		Во спротивно, ја зголемува состојбата на бесилката за 1, со што кога ќе стигне до десната нога, играта завршува и се прикажува прозорче со порака.

		`FillChar();`
		Оваа метода го прави заменувањето на сите цртички во зборот кои што ја содржат избраната буква. 

		Доколку сите цртички се пополнети, играта завршува и се прикажува прозорче со порака.
			
	3.2.3 Помош избор
		`GetHelp();`
		Со притискање на копчето **(Помош избор)** или мени опцијата **(Помош избор)**, се повикува оваа метода која открива една рандом буква во зборот и ги заменува сите цртички со таа буква.

		Со секое притискање на копчето се намалува бројот на помош избори.

	3.2.3 Цртање на бесилката
		`Draw();`
		Со помош на оваа метода, на екранот се црта бесилката каскадно.

		Прво се иницијализираат сите променливи потребни за цртањето, потоа за секој дел од човечето се проверува индивидуално според состојбата на бесилката и се исцртува истиот.
	3.3 GUI

	За претставување на бесилката искористена е panel контрола со исцртување на компонентите според нејзините димензии како offset.

---
---

[new_game_screen]: https://raw.githubusercontent.com/filipboshevski/besilka/master/Sliki/start_screen.png "Слика 1"
[resetiraj]: https://raw.githubusercontent.com/filipboshevski/besilka/master/Sliki/resetiraj.png "Слика 2"
[pomos_izbor]: https://raw.githubusercontent.com/filipboshevski/besilka/master/Sliki/pomos_izbor.png "Слика 3"