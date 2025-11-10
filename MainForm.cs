using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using COMP3300Assignment9BernardBawak.Models;
using Newtonsoft.Json;

namespace COMP3300Assignment9BernardBawak
{
    public partial class MainForm : Form
    {
        private List<SavingsAccount> savingsAccounts;
        private List<CheckingAccount> checkingAccounts;
        private List<MoneyMarketAccount> moneyMarketAccounts;

        public MainForm()
        {
            InitializeComponent();
            savingsAccounts = new List<SavingsAccount>();
            checkingAccounts = new List<CheckingAccount>();
            moneyMarketAccounts = new List<MoneyMarketAccount>();
        }

        private void InitializeComponent()
        {
            this.btnSelectFile = new Button();
            this.btnDisplaySavings = new Button();
            this.btnDisplayChecking = new Button();
            this.btnDisplayMoneyMarket = new Button();
            this.txtDisplay = new TextBox();
            this.lblStatus = new Label();
            this.SuspendLayout();

            // btnSelectFile
            this.btnSelectFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(150, 35);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select JSON File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new EventHandler(this.BtnSelectFile_Click);

            // btnDisplaySavings
            this.btnDisplaySavings.Location = new System.Drawing.Point(12, 60);
            this.btnDisplaySavings.Name = "btnDisplaySavings";
            this.btnDisplaySavings.Size = new System.Drawing.Size(150, 35);
            this.btnDisplaySavings.TabIndex = 1;
            this.btnDisplaySavings.Text = "Display Savings";
            this.btnDisplaySavings.UseVisualStyleBackColor = true;
            this.btnDisplaySavings.Enabled = false;
            this.btnDisplaySavings.Click += new EventHandler(this.BtnDisplaySavings_Click);

            // btnDisplayChecking
            this.btnDisplayChecking.Location = new System.Drawing.Point(12, 105);
            this.btnDisplayChecking.Name = "btnDisplayChecking";
            this.btnDisplayChecking.Size = new System.Drawing.Size(150, 35);
            this.btnDisplayChecking.TabIndex = 2;
            this.btnDisplayChecking.Text = "Display Checking";
            this.btnDisplayChecking.UseVisualStyleBackColor = true;
            this.btnDisplayChecking.Enabled = false;
            this.btnDisplayChecking.Click += new EventHandler(this.BtnDisplayChecking_Click);

            // btnDisplayMoneyMarket
            this.btnDisplayMoneyMarket.Location = new System.Drawing.Point(12, 150);
            this.btnDisplayMoneyMarket.Name = "btnDisplayMoneyMarket";
            this.btnDisplayMoneyMarket.Size = new System.Drawing.Size(150, 35);
            this.btnDisplayMoneyMarket.TabIndex = 3;
            this.btnDisplayMoneyMarket.Text = "Display Money Market";
            this.btnDisplayMoneyMarket.UseVisualStyleBackColor = true;
            this.btnDisplayMoneyMarket.Enabled = false;
            this.btnDisplayMoneyMarket.Click += new EventHandler(this.BtnDisplayMoneyMarket_Click);

            // txtDisplay
            this.txtDisplay.Location = new System.Drawing.Point(180, 12);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.ScrollBars = ScrollBars.Vertical;
            this.txtDisplay.Size = new System.Drawing.Size(600, 400);
            this.txtDisplay.TabIndex = 4;

            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(12, 200);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(150, 50);
            this.lblStatus.Text = "Please select a JSON file to begin.";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnDisplayMoneyMarket);
            this.Controls.Add(this.btnDisplayChecking);
            this.Controls.Add(this.btnDisplaySavings);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "MainForm";
            this.Text = "Assignment 9 by Bawak";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Button btnSelectFile;
        private Button btnDisplaySavings;
        private Button btnDisplayChecking;
        private Button btnDisplayMoneyMarket;
        private TextBox txtDisplay;
        private Label lblStatus;

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        string jsonContent = File.ReadAllText(filePath);
                        List<BankAccount> accounts = JsonConvert.DeserializeObject<List<BankAccount>>(jsonContent);

                        // Clear existing collections
                        savingsAccounts.Clear();
                        checkingAccounts.Clear();
                        moneyMarketAccounts.Clear();

                        // Create appropriate account types based on Type property
                        foreach (var account in accounts)
                        {
                            switch (account.Type.ToLower())
                            {
                                case "savings":
                                    savingsAccounts.Add(new SavingsAccount(
                                        account.OwnerName,
                                        account.CurrentBalance,
                                        account.MonthOpened,
                                        account.MonthlyInterestRate));
                                    break;
                                case "checking":
                                    checkingAccounts.Add(new CheckingAccount(
                                        account.OwnerName,
                                        account.CurrentBalance,
                                        account.MonthOpened,
                                        account.MonthlyInterestRate));
                                    break;
                                case "money market":
                                    moneyMarketAccounts.Add(new MoneyMarketAccount(
                                        account.OwnerName,
                                        account.CurrentBalance,
                                        account.MonthOpened,
                                        account.MonthlyInterestRate));
                                    break;
                            }
                        }

                        // Enable display buttons
                        btnDisplaySavings.Enabled = savingsAccounts.Count > 0;
                        btnDisplayChecking.Enabled = checkingAccounts.Count > 0;
                        btnDisplayMoneyMarket.Enabled = moneyMarketAccounts.Count > 0;

                        lblStatus.Text = $"Loaded: {savingsAccounts.Count} Savings, {checkingAccounts.Count} Checking, {moneyMarketAccounts.Count} Money Market";
                        txtDisplay.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnDisplaySavings_Click(object sender, EventArgs e)
        {
            DisplayAccounts(savingsAccounts.Cast<BankAccount>().ToList(), "Savings Accounts");
        }

        private void BtnDisplayChecking_Click(object sender, EventArgs e)
        {
            DisplayAccounts(checkingAccounts.Cast<BankAccount>().ToList(), "Checking Accounts");
        }

        private void BtnDisplayMoneyMarket_Click(object sender, EventArgs e)
        {
            DisplayAccounts(moneyMarketAccounts.Cast<BankAccount>().ToList(), "Money Market Accounts");
        }

        private void DisplayAccounts(List<BankAccount> accounts, string accountType)
        {
            txtDisplay.Clear();
            txtDisplay.AppendText($"{accountType} ({accounts.Count} accounts):\r\n");
            txtDisplay.AppendText("===========================================\r\n\r\n");

            foreach (var account in accounts)
            {
                txtDisplay.AppendText(account.ToString());
                txtDisplay.AppendText("\r\n\r\n");
            }
        }
    }
}

