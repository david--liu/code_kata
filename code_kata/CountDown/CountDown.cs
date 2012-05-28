namespace code_kata.CountDown
{
    public class CountDown
    {
        private int counter = 0;
        public bool IsStopped
        {
            get { return counter == 0; }
        }

        public void Start(int seconds)
        {
            counter = seconds;
        }

        public void Decrease(int seconds)
        {
            counter = counter > seconds ? counter - seconds : 0;
        }
    }
}