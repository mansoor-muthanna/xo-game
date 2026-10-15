

namespace xo_game
{
    public partial class Form1 : Form
    {
        // 1. ÊÚÑíİ ÇáãÊÛíÑÇÊ ÇáÚÇãÉ Úáì ãÓÊæì ÇáßáÇÓ
        bool isTurnX = true; // áÊÍÏíÏ ÇáÏæÑ: true íÚäí ÏæÑ X¡ æ false íÚäí ÏæÑ O
        int turnCount = 0;   // ÚÏÇÏ ÇáäŞÑÇÊ áãÚÑİÉ ãÇ ÅĞÇ ÇäÊåÊ ÇááÚÈÉ ÈÇáÊÚÇÏá (9 ÍÑßÇÊ)

        public Form1()
        {
            InitializeComponent();
        }

        // 2. ÏÇáÉ ãÓÇÚÏÉ áÊäİíĞ ÇáÍÑßÉ (áãäÚ ÊßÑÇÑ ÇáßæÏ İí ßá ÒÑ)
        private void Play(Button btn)
        {
            // ÇáÊÍŞŞ Ãä ÇáÒÑ İÇÑÛ æáã íÊã ÇáÖÛØ Úáíå ãÓÈŞÇğ
            if (btn.Text == "")
            {
                // ØÈÇÚÉ X Ãæ O ÈäÇÁğ Úáì ÇáÏæÑ ÇáÍÇáí
                if (isTurnX == true)
                {
                    btn.Text = "X";
                }
                else
                {
                    btn.Text = "O";
                }

                btn.Enabled = false; // ÊÚØíá ÇáÒÑ áãäÚ ÊÛííÑå áÇÍŞÇğ
                isTurnX = !isTurnX;  // ÚßÓ ÇáÏæÑ (ÅĞÇ ßÇä X íÕÈÍ O æÇáÚßÓ)
                turnCount++;         // ÒíÇÏÉ ÇáÚÏÇÏ ÈÍÑßÉ æÇÍÏÉ
                this.Refresh();
                CheckWinner();       // ÇáÊÍŞŞ ãä æÌæÏ İÇÆÒ ÈÚÏ åĞå ÇáÍÑßÉ
            }
        }

        // 3. ÏÇáÉ İÍÕ ÇáİæÒ Ãæ ÇáÊÚÇÏá
        private void CheckWinner()
        {
            bool winner = false;

            // 1. ÇáİÍÕ ÇáÃİŞí ááÕİæİ ÇáËáÇËÉ
            // ÇáÕİ ÇáÚáæí (3 - 1 - 2)
            if (button3.Text == button1.Text && button1.Text == button2.Text && button3.Text != "") winner = true;
            // ÇáÕİ ÇáÃæÓØ (5 - 7 - 6)
            else if (button5.Text == button7.Text && button7.Text == button6.Text && button5.Text != "") winner = true;
            // ÇáÕİ ÇáÓİáí (8 - 10 - 9)
            else if (button8.Text == button10.Text && button10.Text == button9.Text && button8.Text != "") winner = true;

            // 2. ÇáİÍÕ ÇáÚãæÏí ááÃÚãÏÉ ÇáËáÇËÉ
            // ÇáÚãæÏ ÇáÃíÓÑ (3 - 5 - 8)
            else if (button3.Text == button5.Text && button5.Text == button8.Text && button3.Text != "") winner = true;
            // ÇáÚãæÏ ÇáÃæÓØ (1 - 7 - 10)
            else if (button1.Text == button7.Text && button7.Text == button10.Text && button1.Text != "") winner = true;
            // ÇáÚãæÏ ÇáÃíãä (2 - 6 - 9)
            else if (button2.Text == button6.Text && button6.Text == button9.Text && button2.Text != "") winner = true;

            // 3. ÇáİÍÕ ÇáŞØÑí (ÇáãŞÕ)
            // ÇáŞØÑ ÇáÑÆíÓí (3 - 7 - 9)
            else if (button3.Text == button7.Text && button7.Text == button9.Text && button3.Text != "") winner = true;
            // ÇáŞØÑ ÇáÚßÓí (2 - 7 - 8)
            else if (button2.Text == button7.Text && button7.Text == button8.Text && button2.Text != "") winner = true;
            // ÅÚáÇä ÇáäÊíÌÉ ÅĞÇ æÌÏ İÇÆÒ
            if (winner == true)
            {
                string winnerName = "";
                // ÈãÇ ÃääÇ ŞãäÇ ÈÚßÓ ÇáÏæÑ İí ÏÇáÉ Play¡ ÇáİÇÆÒ åæ ÕÇÍÈ ÇáÏæÑ ÇáÓÇÈŞ
                if (isTurnX == true)
                {
                    winnerName = "O";
                }
                else
                {
                    winnerName = "X";
                }

                MessageBox.Show("ÇáİÇÆÒ åæ: " + winnerName);
                ResetGame(); // ÅÚÇÏÉ ÇááÚÈÉ ÈÚÏ ÇáİæÒ
            }
            // ÅÚáÇä ÇáÊÚÇÏá ÅĞÇ ÇßÊãáÊ 9 ÍÑßÇÊ æáã íİÒ ÃÍÏ
            else if (turnCount == 9)
            {
                MessageBox.Show("ÇäÊåÊ ÇááÚÈÉ ÈÇáÊÚÇÏá!");
                ResetGame(); // ÅÚÇÏÉ ÇááÚÈÉ ÈÚÏ ÇáÊÚÇÏá
            }
        }

        // 4. ÏÇáÉ ÅÚÇÏÉ ÖÈØ ÇááÚÈÉ (íÊã ÇÓÊÏÚÇÄåÇ ÚÈÑ ÇáÒÑ ÇáÑÇÈÚ Ãæ ÈÚÏ ÇäÊåÇÁ ÇááÚÈÉ)
        private void ResetGame()
        {
            isTurnX = true; // ÅÚÇÏÉ ÇáÏæÑ áÜ X
            turnCount = 0;  // ÊÕİíÑ ÇáÚÏÇÏ

            // ÊİÑíÛ ÇáäÕæÕ æÅÚÇÏÉ ÊİÚíá ÇáÃÒÑÇÑ ÇáÊÓÚÉ ÇáÎÇÕÉ ÈÇááÚÈ
            button1.Text = ""; button1.Enabled = true;
            button2.Text = ""; button2.Enabled = true;
            button3.Text = ""; button3.Enabled = true;

            button5.Text = ""; button5.Enabled = true;
            button6.Text = ""; button6.Enabled = true;
            button7.Text = ""; button7.Enabled = true;

            button8.Text = ""; button8.Enabled = true;
            button9.Text = ""; button9.Enabled = true;
            button10.Text = ""; button10.Enabled = true;
        }

        // 5. ÑÈØ ÃÒÑÇÑ ÇááÚÈ ÇáÊÓÚÉ ÈÏÇáÉ Play
        private void button1_Click(object sender, EventArgs e) { Play(button1); }
        private void button2_Click(object sender, EventArgs e) { Play(button2); }
        private void button3_Click(object sender, EventArgs e) { Play(button3); }

        private void button5_Click(object sender, EventArgs e) { Play(button5); }
        private void button6_Click(object sender, EventArgs e) { Play(button6); }
        private void button7_Click(object sender, EventArgs e) { Play(button7); }

        private void button8_Click(object sender, EventArgs e) { Play(button8); }
        private void button9_Click(object sender, EventArgs e) { Play(button9); }
        private void button10_Click(object sender, EventArgs e) { Play(button10); }

        // 6. ÇáÒÑ ÇáÑÇÈÚ ÇáãÎÕÕ áÅÚÇÏÉ ÇááÚÈÉ (Restart)
        private void button4_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}