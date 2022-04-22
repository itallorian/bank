using BANK.WEB.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;

namespace BANK.WEB.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet, Route("~/register")]
        public IActionResult Register([FromQuery(Name = "e")] string email)
        {
            RegisterViewModel viewModel = new RegisterViewModel()
            {
                Email = email
            };

            return View(viewModel);
        }

        [HttpPost, Route("~/register")]
        public IActionResult Register([FromForm] RegisterViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpGet, Route("~/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("~/login")]
        public IActionResult Login([FromForm] LoginViewModel viewModel)
        {
            return View();
        }

        [HttpGet, Route("~/customer/me")]
        public IActionResult Edit()
        {
            EditViewModel viewModel = new EditViewModel()
            {

            };

            return View(viewModel);
        }

        [HttpPost, Route("~/customer/me")]
        public IActionResult Edit([FromForm] EditViewModel viewModel)
        {
            return View(viewModel);
        }


        [HttpGet, Route("~/customer/balance")]
        public IActionResult Balance()
        {
            BalanceViewModel viewModel = new BalanceViewModel()
            {
                AccountNumber = "0000000",
                Balance = "$ 100.00",
                Transactions = new List<TransactionViewModel>()
                {
                    new TransactionViewModel()
                    {
                        DestinationAccount = "000000001",
                        RecipientName = "John Doe",
                        TransactionDate = DateTime.Now,
                        TransactionId = 1,
                        TransactionProtocol = "fdslak124dfsadjl2134",
                        Value = "$ 10.00"
                    },
                    new TransactionViewModel()
                    {
                        DestinationAccount = "000000001",
                        RecipientName = "John Doe",
                        TransactionDate = DateTime.Now,
                        TransactionId = 2,
                        TransactionProtocol = "fdslak124sdfsadjl2134",
                        Value = "$ 10.00"
                    },
                                        new TransactionViewModel()
                    {
                        DestinationAccount = "000000001",
                        RecipientName = "John Doe",
                        TransactionDate = DateTime.Now,
                        TransactionId = 3,
                        TransactionProtocol = "fdslak124sdfsadjl2134",
                        Value = "$ 10.00"
                    },
                                                            new TransactionViewModel()
                    {
                        DestinationAccount = "000000001",
                        RecipientName = "John Doe",
                        TransactionDate = DateTime.Now,
                        TransactionId = 4,
                        TransactionProtocol = "fdslak124sdfsadjl2134",
                        Value = "$ 10.00"
                    },
                                                                                new TransactionViewModel()
                    {
                        DestinationAccount = "000000001",
                        RecipientName = "John Doe",
                        TransactionDate = DateTime.Now,
                        TransactionId = 5,
                        TransactionProtocol = "fdslak124sdfsadjl2134",
                        Value = "$ 10.00"
                    },
                                                                                                    new TransactionViewModel()
                    {
                        DestinationAccount = "000000001",
                        RecipientName = "John Doe",
                        TransactionDate = DateTime.Now,
                        TransactionId = 6,
                        TransactionProtocol = "fdslak124sdfsadjl2134",
                        Value = "$ 10.00"
                    },
                                                                                                                        new TransactionViewModel()
                    {
                        DestinationAccount = "000000001",
                        RecipientName = "John Doe",
                        TransactionDate = DateTime.Now,
                        TransactionId = 7,
                        TransactionProtocol = "fdslak124sdfsadjl2134",
                        Value = "$ 10.00"
                    }
                }
            };

            return View(viewModel);
        }
    }
}
