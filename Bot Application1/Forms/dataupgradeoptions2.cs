using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Forms
{
    [Serializable]
    public class BucketUpgrade
    {
        public enum UpgradeOptions { Frihet6GB, Frihet12GB, Frihet24GB, Frihet50GB };

        public static IForm<BucketUpgrade> MakeForm()
        {
            FormBuilder<BucketUpgrade> _DataUpgrade = new FormBuilder<BucketUpgrade>();
            return _DataUpgrade
                .Message("Ok, in need ...")
                .Field(nameof(BucketSize)) //, active: ValidateUserNumber) - not required, but will be nice later
                .Message("Thanks, you selected {BucketSize}, right?")
                .AddRemainingFields()
                .Build();
        }

        [Prompt("What {&} would you want? {||}")]
        public UpgradeOptions? Frihet6GB;
        [Describe("Please select the size of your new data limit.")]
        public string BucketSize;

    }
}
