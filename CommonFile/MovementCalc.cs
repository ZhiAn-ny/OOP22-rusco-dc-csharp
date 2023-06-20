namespace OOP22_rusco_dc_csharp.CommonFile
{
    public static class MovementCalc
    {
        private static Tuple<int, int> Compute(Tuple<int, int> startPos, int offset, bool OnXSpace)
        {
            int x = startPos.Item1;
            int y = startPos.Item2;
            if (OnXSpace)
            {
                return new Tuple<int, int>(x + offset, y);
            }
            else
            {
                return new Tuple<int, int>(x, y + offset);
            }
        }
        public static Tuple<int, int> ComputeUpPos(Tuple<int, int> oldPos)
        {
            return Compute(oldPos, -1, false);
        }

        public static Tuple<int, int> ComputeDownPos(Tuple<int, int> oldPos)
        {
            return Compute(oldPos, 1, false);
        }

        public static Tuple<int, int> ComputeLeftPos(Tuple<int, int> oldPos)
        {
            return Compute(oldPos, -1, true);
        }

        public static Tuple<int, int> ComputeRightPos(Tuple<int, int> oldPos)
        {
            return Compute(oldPos, 1, true);
        }
    }
}