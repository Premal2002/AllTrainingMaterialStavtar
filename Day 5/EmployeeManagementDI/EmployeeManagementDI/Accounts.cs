namespace EmployeeManagementDI
{
    public class Accounts
    {
        public  int AccId { get; set; }
        public string AccName { get; set; }
        public string AccType { get; set; }
        public double AccBalance { get; set; }
        public bool AccIsActive { get; set; }

        static private List<Accounts> accList = new List<Accounts>()
        {
            new Accounts(){ AccId = 1, AccName = "Premal", AccType = "Saving", AccBalance = 40000, AccIsActive = true},
            new Accounts(){ AccId = 2, AccName = "Sandip", AccType = "Current", AccBalance = 50000, AccIsActive = true},
            new Accounts(){ AccId = 3, AccName = "Sammer", AccType = "PF", AccBalance = 60000, AccIsActive = true},
            new Accounts(){ AccId = 4, AccName = "Harsh", AccType = "Saving", AccBalance = 30000, AccIsActive = true},
            new Accounts(){ AccId = 5, AccName = "Saurabh", AccType = "Current", AccBalance = 80000, AccIsActive = true}
        };

        #region Methods
        public List<Accounts> AllAccounts()
        {
            return accList;
        }

        public List<Accounts> GetAccountsByAccId(int accId)
        {
            var ab = (from a in accList
                     where a.AccId == accId
                     select a).ToList();
            if(ab != null)
            {
                return ab;
            }
            throw new Exception("Accounts not found with " + accId + " this account Id");
        }

        public string AddAccount(Accounts account)
        {
            accList.Add(account);
            return "Account added successfully";
        }
        #endregion
    }
}
