using System;
using StructureMap;
using StructureMap.Graph;

namespace Calculator
{
    class Program
    {
        private const string enterNumber = "> Enter a number: ";
        private const string enterAnotherNumber = "> Enter another number: ";
        private const string enterOperator = "> Enter an operator (+/-): ";

        static void Main(string[] args)
        {
            ConfigureStructuremap();

            IProcessor _processor = ObjectFactory.GetInstance<IProcessor>();
            IValidator _validator= ObjectFactory.GetInstance<IValidator>();

            Console.WriteLine(enterNumber);

            while (true)
            {
                try
                {
                    string command = Console.ReadLine();

                    switch (_processor.Commands.Count)
                    {
                        case 0:
                            if (_validator.IsIntString(command))
                            {
                                _processor.AddCommand(command);
                                Console.WriteLine(enterAnotherNumber);
                            }
                            else
                            {
                                Console.WriteLine(enterNumber);
                            }
                            break;
                        case 1:
                            if (_validator.IsIntString(command))
                            {
                                _processor.AddCommand(command);
                                Console.WriteLine(enterOperator);
                            }
                            else
                            {
                                Console.WriteLine(enterAnotherNumber);
                            }
                            break;
                        case 2:
                            if (_validator.IsValidOperator(command))
                            {
                                _processor.AddCommand(command);
                                string result = _processor.Calculate();
                                Console.WriteLine(string.Format("Result: {0}",result));
                            }
                            else
                            {
                                Console.WriteLine(enterOperator);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ConfigureStructuremap()
        {
            ObjectFactory.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                config.For<ILogger>().Use<Logger>();
                config.For<IValidator>().Use<Validator>();
                config.For<ICalculator<int>>().Use<IntCalculator>();
                config.For<IProcessor>().Use<Processor>();
            });
        }
    }
}
