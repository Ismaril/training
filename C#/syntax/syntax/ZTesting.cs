

// This file is only used for just testing of code and shit.


namespace syntax
{
    internal class ZTesting
    {
        int Param { get; set; }

        internal ZTesting(int param)
        {
            this.Param = param;
        }
    }

    internal class XXX : ZTesting 
    {
        int Param2 { get; set; }

        internal XXX(int param, int param2) : base(param)
        {
            this.Param2 = param2;
        }

    }


}   

