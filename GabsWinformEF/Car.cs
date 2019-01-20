using System;

namespace GabsWinformEF
{
    class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Type { get; set; }
        public string Color { get; set; }
    }

    class CarType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    class CarIdGenerator
    {
        public int Id { get; set; }
    }
}
