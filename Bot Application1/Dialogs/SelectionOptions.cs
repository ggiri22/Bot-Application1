using System;
using System.Collections;

namespace BotApplication1.Dialogs
{
    //feedback options
    public class FeedbackOption
    {
        public FeedbackOption(string answr, string dmy)
        {
            this.answer = answr;
            this.dummy = dmy;
        }

        public string answer;
        public string dummy;
    }

    // Collection of UpgradeOption objects. This class
    // implements IEnumerable so that it can be used
    // with ForEach syntax.
    public class FeedbackOptions : IEnumerable
    {
        private FeedbackOption[] _feedbackoptions;
        public FeedbackOptions(FeedbackOption[] oArray)
        {
            _feedbackoptions = new FeedbackOption[oArray.Length];

            for (int i = 0; i < oArray.Length; i++)
            {
                _feedbackoptions[i] = oArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public FeedbackOptionEnum GetEnumerator()
        {
            return new FeedbackOptionEnum(_feedbackoptions);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class FeedbackOptionEnum : IEnumerator
    {
        public FeedbackOption[] _feedbackoptions;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public FeedbackOptionEnum(FeedbackOption[] list)
        {
            _feedbackoptions = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _feedbackoptions.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public FeedbackOption Current
        {
            get
            {
                try
                {
                    return _feedbackoptions[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    // Simple business object.
    public class UpgradeOption
    {
        public UpgradeOption(string dAmount, string mCost)
        {
            this.dataAmount = dAmount;
            this.monthlyCost = mCost;
        }

        public string dataAmount;
        public string monthlyCost;
    }

    // Collection of UpgradeOption objects. This class
    // implements IEnumerable so that it can be used
    // with ForEach syntax.
    public class UpgradeOptions : IEnumerable
    {
        private UpgradeOption[] _upgradeoptions;
        public UpgradeOptions(UpgradeOption[] oArray)
        {
            _upgradeoptions = new UpgradeOption[oArray.Length];

            for (int i = 0; i < oArray.Length; i++)
            {
                _upgradeoptions[i] = oArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public UpgradeOptionEnum GetEnumerator()
        {
            return new UpgradeOptionEnum(_upgradeoptions);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class UpgradeOptionEnum : IEnumerator
    {
        public UpgradeOption[] _upgradeoptions;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public UpgradeOptionEnum(UpgradeOption[] list)
        {
            _upgradeoptions = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _upgradeoptions.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public UpgradeOption Current
        {
            get
            {
                try
                {
                    return _upgradeoptions[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public class SigninOption
    {
        public SigninOption(string selOption)
        {
            this.selectedOption = selOption;
        }

        public string selectedOption;
    }
    public class SigninOptions : IEnumerable
    {
        private SigninOption[] _signinoptions;
        public SigninOptions(SigninOption[] oArray)
        {
            _signinoptions = new SigninOption[oArray.Length];

            for (int i = 0; i < oArray.Length; i++)
            {
                _signinoptions[i] = oArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public SigninOptionEnum GetEnumerator()
        {
            return new SigninOptionEnum(_signinoptions);
        }
    }
    public class SigninOptionEnum : IEnumerator
    {
        public SigninOption[] _signinoptions;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public SigninOptionEnum(SigninOption[] list)
        {
            _signinoptions = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _signinoptions.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public SigninOption Current
        {
            get
            {
                try
                {
                    return _signinoptions[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}