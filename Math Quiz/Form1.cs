using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer
        // to generate random numbers.
        Random randomizer = new Random();

        // integer variables for addition problem.
        int addend1;
        int addend2;
        // integer variables for subtraction problem.
        int minuend;
        int subtrahend;
        // integer variables for multiplication problem.
        int multiplicand;
        int multiplier;
        // integer variables for division problem.
        int divisor;
        int dividend;

        // integer variable keeps track of time remaining.
        int timeLeft;
    
      

        /// <summary>
        /// Start the quiz by filling in all of the problems 
        /// and starting the timer
        /// </summary>
        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so they can be displayed in labels.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // Set value to zero before adding values to it.
            sum.Value = 0;
            // Set color of NumericUpDowns to white
            sum.BackColor = difference.BackColor = product.BackColor = 
                quotient.BackColor = Color.White;

            // Fill in the subtraction problem.
            // Generate two random numbers to subtract.
            // Store the values in the variables 'minuend' and 'subtrahend'.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in multiplation problem.
            // Generate two random numbers to multiply.
            // Store the values int he variables 'multiplicand' and 'multiplier'
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            
            // insert date
            var today = DateTime.Now.Date;
            date.Text = today.ToString("dd MMMM yyyy");
            // reset timer color
            timeLabel.BackColor = Color.LightGreen;

            // start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        /// <summary>
        /// Check the answer to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer is correct, else false.</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
            { 
                return true;
            }
            else
            {
                if (sum.Value > 0 && sum.Value != addend1 + addend2)
                {
                    sum.BackColor = Color.LightPink;
                }
                else
                {
                    sum.BackColor = Color.White;
                }
                if (difference.Value != 0 && minuend - subtrahend != difference.Value)
                {
                    difference.BackColor = Color.LightPink;
                }
                else
                {
                    difference.BackColor = Color.White;
                }
                if (product.Value != 0 && multiplicand * multiplier != product.Value)
                {
                    product.BackColor = Color.LightPink;
                }
                else
                {
                    product.BackColor = Color.White;
                }
                if (quotient.Value != 0 && dividend / divisor != quotient.Value)
                {
                    quotient.BackColor = Color.LightPink;
                }
                else
                {
                    quotient.BackColor = Color.White;
                }
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
            startButton.BackColor = Color.SteelBlue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer()) 
            {
                // if CheckTheAnswer() returns true, user is right.
                // Stop timer and show MessageBox.
                timer1.Stop();
                sum.BackColor = difference.BackColor = product.BackColor = 
                    quotient.BackColor = Color.White;
                


                MessageBox.Show("You got the answer right!",
                                 "Congratulations!");
                startButton.Enabled = true;
                startButton.BackColor = Color.LightSteelBlue;
                



            }
            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft > 15)
                {
                    timeLabel.BackColor = Color.LightGreen;
                }
                else if (timeLeft > 10)
                {
                    timeLabel.BackColor = Color.Yellow;
                }
                else if (timeLeft > 5)
                {
                    timeLabel.BackColor = Color.Gold;
                }
                else if (timeLeft > 2)
                {
                    timeLabel.BackColor = Color.Orange;
                }
                else if (timeLeft > 0)
                {
                    timeLabel.BackColor = Color.DarkOrange;
                }
                else
                {
                    timeLabel.BackColor = Color.Red;
                }
               
            }
            else
            {
                // If the user ran out of time, stop timer
                // show a MessageBox, and fill in answers.
                
                timer1.Stop();
                if (sum.Value == 0)
                {
                    sum.BackColor = Color.LightPink;
                }
                if (difference.Value == 0)
                {
                    difference.BackColor = Color.LightPink;
                }
                if (product.Value == 0)
                { 
                    product.BackColor = Color.LightPink;
                }
                if (quotient.Value == 0)
                {
                    quotient.BackColor = Color.LightPink;
                }
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                timeLabel.BackColor = Color.LightSteelBlue;
                startButton.Enabled = true;
                startButton.BackColor = Color.LightSteelBlue;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var today = DateTime.Now.Date;
            date.Text = today.ToString("dd MMMM yyyy");
        }


    }
}
