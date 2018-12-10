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
using Operations;
using Microsoft.Win32;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int displayInt = 0;
        private double displayDouble = 0;

        private int operation = -1; //the status of the current operator

        private int isCleared = 0; //whether the clear btn being used
        private bool isPointed = false; //for each real number have only one point
        private bool isFloated = false;
        private bool isOperated = false; //in each operation only one operator in it

        //After click any other btns, the status of the btn will be set to clear not all clear.
        private void clear()
        {
            isCleared = 0;
            clearBtn.Content = "C";
        }

        //the equal operation for the equal btn and the operators when doing continously operations.
        private void equal(int operation)
        {
            switch (operation)
            {
                case 1:
                    displayDouble =
                        Class1.plusDouble(displayDouble, Convert.ToDouble(displayTxt.Text));
                    displayTxt.Text = "" + displayDouble;
                    break;
                case 2:
                    displayDouble =
                        Class1.minusDouble(displayDouble, Convert.ToDouble(displayTxt.Text));
                    displayTxt.Text = "" + displayDouble;
                    break;
                case 3:
                    displayDouble =
                        Class1.mulDouble(displayDouble, Convert.ToDouble(displayTxt.Text));
                    displayTxt.Text = "" + displayDouble;
                    break;
                case 4:
                    // if the number being divided is zero, the calculator will warn u.
                    if (Convert.ToDouble(displayTxt.Text) == 0)
                    {
                        displayTxt.Text = "ERROR";
                    }
                    else
                    {
                        displayDouble =
                        Class1.divDouble(displayDouble, Convert.ToDouble(displayTxt.Text));
                        displayTxt.Text = "" + displayDouble;
                    }
                    break;
                default:
                    break;
            }
        }
        
        // the numbers
        private void oneBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)//if is operated then it will need a following number to do continous operation
            {
                displayTxt.Text = "1";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "1";
            }
            isOperated = false;
        }

        private void twoBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "2";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "2";
            }
            isOperated = false;
        }

        private void threeBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "3";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "3";
            }
            isOperated = false;
        }

        private void fourBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "4";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "4";
            }
            isOperated = false;
        }

        private void fiveBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "5";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "5";
            }
            isOperated = false;
        }

        private void sixBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "6";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "6";
            }
            isOperated = false;
        }

        private void sevenBtn_Click_1(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "7";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "7";
            }
            isOperated = false;
        }

        private void eightBtn_Click_1(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "8";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "8";
            }
            isOperated = false;
        }

        private void nightBtn_Click_1(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "9";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "9";
            }
            isOperated = false;
        }

        private void zeroBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (displayTxt.Text == "0" || isOperated)
            {
                displayTxt.Text = "0";
            }
            else
            {
                displayTxt.Text = displayTxt.Text + "0";
            }
        }

        //the clear btn
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isCleared != 0)//all clear, which need click the btn twice 
            {
                displayTxt.Text = "0";
                displayInt = 0;
                displayDouble = 0;
                oprTxt.Text = "";
                operation = -1;

                isPointed = false;
                isFloated = false;
                isCleared++;
                //clearBtn.Content = "C";
            }
            else {//clear the current number and the status changes
                displayTxt.Text = "0";
                isCleared++;
                clearBtn.Content = "AC";
            }

        }

        private void percentBtn_Click(object sender, RoutedEventArgs e)
        {
            displayDouble = Convert.ToDouble(displayTxt.Text);
            displayDouble = displayDouble / 100;
            displayTxt.Text = "" + displayDouble;
            isFloated = true;
            clear();
        }

        // the real number btn
        private void pointBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (isPointed == false)
            {
                if (displayTxt.Text == "" || isOperated)
                {
                    displayTxt.Text = "0.";
                }
                else
                {
                    displayTxt.Text = displayTxt.Text + ".";
                }
            }
            isPointed = true;
            isFloated = true;
            isOperated = false;
        }

        private void signBtn_Click(object sender, RoutedEventArgs e)
        {
            displayDouble = 0 - Convert.ToDouble(displayTxt.Text);
            displayTxt.Text = "" + displayDouble;
            clear();
        }

        //the operators
        private void divBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (operation == 1 || operation == 2 || operation == 3 || operation == 4) {
                equal(operation);
            }// in order to do continous operation
            if (isOperated)// to change the operator not to do the operation
            {
                operation = 4;
                oprTxt.Text = "/";
                isOperated = true;
                isPointed = false;
            }
            else {
                displayDouble = Convert.ToDouble(displayTxt.Text);
                operation = 4;
                oprTxt.Text = "/";
                isOperated = true;
                isPointed = false;
            }
        }
       
        private void plusBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (operation == 1 || operation == 2 || operation == 3 || operation == 4)
            {
                equal(operation);
            }
            if (isOperated) {
                operation = 1;
                oprTxt.Text = "+";
                isOperated = true;
                isPointed = false;
            }
            else {
                displayDouble = Convert.ToDouble(displayTxt.Text);
                operation = 1;
                oprTxt.Text = "+";
                isOperated = true;
                isPointed = false;
            }
        }

        private void minusBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (operation == 1 || operation == 2 || operation == 3 || operation == 4)
            {
                equal(operation);
            }
            if (isOperated) {
                operation = 2;
                oprTxt.Text = "-";
                isOperated = true;
                isPointed = false;
            }
            else {
                displayDouble = Convert.ToDouble(displayTxt.Text);
                operation = 2;
                oprTxt.Text = "-";
                isOperated = true;
                isPointed = false;
            }
        }

        private void mulBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (operation == 1 || operation == 2 || operation == 3 || operation == 4)
            {
                equal(operation);
            }
            if (isOperated) {
                operation = 3;
                oprTxt.Text = "×";
                isOperated = true;
                isPointed = false;
            }
            else
            {
                displayDouble = Convert.ToDouble(displayTxt.Text);
                operation = 3;
                oprTxt.Text = "×";
                isOperated = true;
                isPointed = false;
            }
        }

        private void equalBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            equal(operation);
            operation = -1;
            oprTxt.Text = "=";
            isOperated = true;
        }
    }
}
