﻿using System;
using System.Windows.Forms;

namespace wf_poll_cwe
{
    public partial class PollForm : Form
    {
        private IPoller poller;

        public PollForm()
        {
            //ORDER MATTERS! Components have a dependency on poller
            poller = new Poller();
            InitializeComponent();

        }

            private void submitVote(string vote)
            {
                try
                {
                    poller.SaveVote(vote);
                }
                catch
                {
                    lblResults.Text = "Sorry, unable to process request. Please try again.";
                }
            }

            private void butResults_Click(object sender, EventArgs e)
            {
                var results = poller.GetPollResults();
                string cOne = poller.GetCandidates().CandidateOne;
                string cTwo = poller.GetCandidates().CandidateTwo;
                lblResults.Text =
                cOne + ": " + results[cOne].Total + " votes (" + results[cOne].Percent + "%).\n" +
                cTwo + ": " + results[cTwo].Total + " votes (" + results[cTwo].Percent + "%).\n\n";
            }

            private void butSubmit_Click(object sender, EventArgs e)
            {
                if (CandidateOne.Checked == true)
                    submitVote(poller.GetCandidates().CandidateOne);
                else if (CandidateTwo.Checked == true)
                    submitVote(poller.GetCandidates().CandidateTwo);
            }

        private void PollForm_Load(object sender, EventArgs e)
        {

        }

        private void IM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    }