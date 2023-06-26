using Besilka.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Besilka.Models
{
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
}
