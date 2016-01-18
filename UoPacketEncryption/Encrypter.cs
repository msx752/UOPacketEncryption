using System;

namespace UoPacketEncryption
{
    public static class Encrypter
    {
        public static UOCrypt uoc = new UOCrypt();

        private static uint LOGINKEY1_V2_0_3 = 0x2DBBB7CD;
        private static uint LOGINKEY2_V2_0_3 = 0xA3C95E7F;
        public static CryptMode m_crypt_mode = CryptMode.None;

        //use this if packet first byte == 0x80  (ONCE)
        public static void set_login_encryption()
        {
            m_crypt_mode = CryptMode.Login;
            uoc.LogCrypt.init(LOGINKEY1_V2_0_3, LOGINKEY2_V2_0_3);
        }

        //use this if packet first byte == 0x91  (ONCE)
        public static void set_game_encryption()
        {
            m_crypt_mode = CryptMode.Game;
            uoc.GamCrypt.init();
        }

        //use this if packet first byte == 0xC0  (ONCE)
        public static void SEED(byte[] PACKET)
        {
            uint[] pseed = new uint[PACKET.Length];
            for (int i = 0; i < PACKET.Length; i++)
            {
                pseed[i] = Convert.ToUInt32(PACKET[i]);
            }
            uoc.LogCrypt.SEEDK = pseed;
        }
    }
}