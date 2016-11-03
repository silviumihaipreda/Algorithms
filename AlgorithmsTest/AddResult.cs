using System.Text;

namespace StridesTest
{
    public class AddResult
    {
        private byte[] f;
        private byte[] result;
        private byte[] s;

        public AddResult(byte[] f, byte[] s, byte[] result)
        {
            this.f = f;
            this.s = s;
            this.result = result;
        }

        public override bool Equals(object obj)
        {
            var addResult = obj as AddResult;
            if (addResult == null)
            {
                return false;
            }

            return Compare(f, addResult.f)
                && Compare(s, addResult.s)
                && Compare(result, addResult.result);
        }

        private bool Compare(byte[] b1, byte[] b2)
        {
            return Encoding.ASCII.GetString(b1) == Encoding.ASCII.GetString(b2);
        }
    }
}