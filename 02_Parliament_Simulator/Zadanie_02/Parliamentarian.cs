namespace Zadanie_02
{

    class Parliamentarian
    {
        private int id;
        private bool canVote;
        public event EventHandler<bool> Vote;
        public Parliamentarian(int id)
        {
            this.id = id;
            canVote = false;
        }

        public void DoVote()
        {
            if (canVote)
            {
                var random = new Random();
                bool myVote = (random.Next(2) == 1) ? true : false;

                Vote?.Invoke(this, myVote);
                Console.WriteLine($"GŁOS {id}: {(myVote ? "ZA" : "PRZECIW")}");
            }
            else
            {
                Console.WriteLine("Nie możesz oddać głosu!");
            }
        }

        public void parliament_VotingStarted(object sender, string topic)
        {
            canVote = true;
            DoVote();
        }

        public void parliament_VotingCompleted(object sender, EventArgs e)
        {
            canVote = false;
        }

        public void SubscribeParliamentarianToVotingStarted(Parliament parliament)
        {
            parliament.VotingStarted += parliament_VotingStarted;
        }

        public void UnsubscribeParliamentarianFromVotingStarted(Parliament parliament)
        {
            parliament.VotingStarted -= parliament_VotingStarted;
        }

        public void SubscribeParliamentarianToVotingCompleted(Parliament parliament)
        {
            parliament.VotingCompleted += parliament_VotingCompleted;
        }

        public void UnsubscribeParliamentarianFromVotingCompleted(Parliament parliament)
        {
            parliament.VotingCompleted -= parliament_VotingCompleted;
        }

    }
}
