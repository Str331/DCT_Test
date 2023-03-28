using DCT_Test.DCT.Domain.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT_Test.DCT.Domain.Infrastructure.Commands
{
     class Command: BaseCommand
    {
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> execute;

        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.canExecute = canExecute;
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public override bool CanExecute(object value) =>
            this.canExecute?.Invoke(value) ?? true;

        public override void Execute(object value) =>
            this.execute(value);
    }
}
