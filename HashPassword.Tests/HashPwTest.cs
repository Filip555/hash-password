using System;
using Xunit;

namespace HashPassword.Tests
{
    public class HashPwTest
    {
        [Fact]
        public void Hash_system_should_return_the_correct_hashed_password()
        {
            const string password = "secretpw";
            var hashSystem = new HashPw();

            var salt = "CV5QNYON27MkyFrbiZViitcxfdXZHdHvsE7kSAu4UQ5f9GkxmhMszA ==";
            var hashPassword = hashSystem.GetHash(password, salt);

            Assert.Equal("AGd+jMv/HauI86d9nRSa568irLdYgWjrHfVALjQ1g04VJLSUucMnEA==", hashPassword);
        }
        [Fact]
        public void Hash_system_all_time_genereate_the_same_hash_password_if_we_give_him_the_same_salt()
        {
            const string password = "secretpw";
            var hashSystem = new HashPw();

            var salt = hashSystem.GetSalt();
            var hashPassword = hashSystem.GetHash(password, salt);
            var secondHashPassword = hashSystem.GetHash(password, salt);

            Assert.Equal(hashPassword, secondHashPassword);
        }
        [Fact]
        public void Hash_password_will_be_diffrent_for_the_same_user_password_with_diffrent_salt()
        {
            const string password = "secretpw";
            var hashSystem = new HashPw();

            var salt = hashSystem.GetSalt();
            var hashPassword = hashSystem.GetHash(password, salt);
            var saltForSecond = hashSystem.GetSalt();
            var secondHashPassword = hashSystem.GetHash(password, saltForSecond);

            Assert.NotEqual(hashPassword, secondHashPassword);
        }
    }
}
