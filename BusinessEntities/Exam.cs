using System;

namespace BusinessEntities
{
    public class Exam : IdObject
    {
        private string _title;
        private string _description;
        private int _durationMinutes;
        private int _maxScore;

        public string Title
        {
            get => _title;
            private set => _title = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public int DurationMinutes
        {
            get => _durationMinutes;
            private set => _durationMinutes = value;
        }

        public int MaxScore
        {
            get => _maxScore;
            private set => _maxScore = value;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Title was not provided.");
            }
            _title = title;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public void SetDurationMinutes(int durationMinutes)
        {
            if (durationMinutes <= 0)
            {
                throw new ArgumentException("Duration must be greater than zero.");
            }
            _durationMinutes = durationMinutes;
        }

        public void SetMaxScore(int maxScore)
        {
            if (maxScore <= 0)
            {
                throw new ArgumentException("Max score must be greater than zero.");
            }
            _maxScore = maxScore;
        }
    }
}
