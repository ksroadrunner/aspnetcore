using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Abstractions.Test;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ISingletonService singleton;
        private readonly ISingletonService singleton2;

        private readonly ITransientService transient;
        private readonly ITransientService transient2;

        private readonly IScopedService scoped;
        private readonly IScopedService scoped2;

        public ServiceController(ISingletonService singleton,
                                 ISingletonService singleton2,
                                 ITransientService transient,
                                 ITransientService transient2,
                                 IScopedService scoped,
                                 IScopedService scoped2)
        {
            this.singleton = singleton;
            this.singleton2 = singleton2;

            this.transient = transient;
            this.transient2 = transient2;

            this.scoped = scoped;
            this.scoped2 = scoped2;
        }


        public IActionResult Index()
        {
            return View(new[] {
                this.singleton.Generate(),
                this.singleton2.Generate(),

                this.transient.Generate(),
                this.transient2.Generate(),

                this.scoped.Generate(),
                this.scoped2.Generate()
            });
        }

        public IActionResult Index2()
        {
            return View();
        }
    }
}