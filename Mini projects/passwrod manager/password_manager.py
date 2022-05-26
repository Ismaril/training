from cryptography.fernet import Fernet

KEY = b'wv0Qaap6H4yAZ6A8ohjxI1FtIIOV9FO7fJDQ_sUzpIU='


class PasswordManager:

    def __init__(self):
        self.f = Fernet(KEY)

    def encrypt(self, x):
        """Encrypt input x"""
        return self.f.encrypt(bytes(x.encode())).decode()

    def decrypt_master_password(self, x):
        with open("passw.txt", "r") as f_read:
            read = f_read.readline().encode()
        return self.f.decrypt(bytes(read)).decode()

    def decrypt_whole_text(self):
        with open("passw.txt", "r") as f_read:
            read = f_read.readlines()
            decrypted = []
            for encryption in read:
                encoded = encryption.encode()
                decoded = self.f.decrypt(bytes(encoded)).decode()
                decrypted.append(str(decoded))
            decrypted.insert(0, "Master password:")
        return "\n".join(decrypted)

    def read_passwords(self):
        print("***Read passwords***")
        i = 0
        while i < 3:
            master_query = input("Enter your master password: ").strip()
            with open("passw.txt", "r") as f_read:
                read = f_read.read()

            if master_query == self.decrypt_master_password(master_query):
                print(self.decrypt_whole_text())
                break
            elif master_query != read:
                print(f"Incorrect master password, you got {2 - i}/3 attempts left")
            i += 1

    def write_passwords(self):
        print("***Write passwords***")
        i = 0
        while i < 3:
            master_password = input("Enter your master password: ").strip()
            with open("passw.txt", "r") as f_read:
                read_line = f_read.readline()

            # set new master password if opening the file for the first time
            if not read_line:
                with open("passw.txt", "w") as f_write:
                    f_write.write(self.encrypt(master_password))
                    print("Your new master password was set\n")
                break

            # write new data
            if master_password == self.decrypt_master_password(master_password):
                new_data = input("Page, login, password: ")
                with open("passw.txt", "a") as f_append:
                    f_append.write(f"\n{self.encrypt(new_data)}")
                print("New data successfully added to database\n")
                break

            # give a user 3 attempts to get inside
            if master_password != self.decrypt_master_password(master_password):
                print(f"Incorrect master password, you got {2 - i}/3 attempts left")
                i += 1

    def main(self):
        while True:
            start_input = input("Read your passwords (r), Write new passwords (w), Quit (q): ").lower()
            if start_input == "r":
                with open("passw.txt", "r") as f_read:
                    if not f_read.read():
                        print("You do not have set any Master password\n")
                        self.write_passwords()
                self.read_passwords()
            elif start_input == "w":
                self.write_passwords()
            elif start_input == "q":
                print("***Quitting***")
                break


if __name__ == '__main__':
    pm = PasswordManager()
    pm.main()

# p*i*c*a
