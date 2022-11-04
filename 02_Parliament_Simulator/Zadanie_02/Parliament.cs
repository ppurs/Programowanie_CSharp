namespace Zadanie_02
{
    class Parliament
    {
        public event EventHandler<string> VotingStarted;
        public event EventHandler VotingCompleted;

        private List<Parliamentarian> parlamentarians;
        private string electionTopic;
        private int votesFor;
        private int votesAgainst;

        public Parliament(int noParliamentarians)
        {
            CreateParlamentarians(noParliamentarians);

            electionTopic = "";
            votesFor = 0;
            votesAgainst = 0;
        }

        public void ConductVoting(string topic)
        {
            SubscribeParliamentToVote();
            SubscribeParliamentariansToVotingStarted();

            StartVoting(topic);

            UnsubscribeParliamentariansFromVotingStarted();
            UnsubscribeParliamentFromVote();
            SubscribeParliamentariansToVotingCompleted();

            EndVoting();

            UnsubscribeParliamentariansFromVotingCompleted();
        }

        public (string, int, int) GetVotingResult()
        {
            return (electionTopic, votesFor, votesAgainst);
        }

        private void StartVoting(string topic)
        {
            votesFor = 0;
            votesAgainst = 0;

            electionTopic = topic;
            Console.WriteLine($"\nPOCZATEK {topic}");

            VotingStarted?.Invoke(this, topic);
        }

        private void EndVoting()
        {
            VotingCompleted?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("KONIEC");
        }

        private void parliamentarian_Vote(object sender, bool vote)
        {
            if (vote)
            {
                votesFor++;
            }
            else
            {
                votesAgainst++;
            }
        }

        private void SubscribeParliamentariansToVotingStarted()
        {
            foreach (Parliamentarian obj in parlamentarians)
            {
                obj.SubscribeParliamentarianToVotingStarted(this);
            }
        }

        private void UnsubscribeParliamentariansFromVotingStarted()
        {
            foreach (Parliamentarian obj in parlamentarians)
            {
                obj.UnsubscribeParliamentarianFromVotingStarted(this);
            }
        }

        private void SubscribeParliamentariansToVotingCompleted()
        {
            foreach (Parliamentarian obj in parlamentarians)
            {
                obj.SubscribeParliamentarianToVotingCompleted(this);
            }
        }

        private void UnsubscribeParliamentariansFromVotingCompleted()
        {
            foreach (Parliamentarian obj in parlamentarians)
            {
                obj.UnsubscribeParliamentarianFromVotingCompleted(this);
            }
        }

        private void SubscribeParliamentToVote()
        {
            foreach (Parliamentarian obj in parlamentarians)
            {
                obj.Vote += parliamentarian_Vote;
            }
        }

        private void UnsubscribeParliamentFromVote()
        {
            foreach (Parliamentarian obj in parlamentarians)
            {
                obj.Vote -= parliamentarian_Vote;
            }
        }

        private void CreateParlamentarians(int noParliamentarians)
        {
            parlamentarians = new List<Parliamentarian>();

            for (int i = 0; i < noParliamentarians; i++)
            {
                parlamentarians.Add(new Parliamentarian(i + 1));
            }
        }
    }
}
