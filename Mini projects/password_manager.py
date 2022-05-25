from cryptography.fernet import Fernet
import tkinter


def main():

    key = b'wv0Qaap6H4yAZ6A8ohjxI1FtIIOV9FO7fJDQ_sUzpIU='
    f = Fernet(key)

    def encrypt(x):
        return f.encrypt(bytes(x.encode())).decode()

    def decrypt(x):
        with open("unsorted/passw.txt", "r") as f_read:
            read = f_read.readline().encode()
        return f.decrypt(bytes(read)).decode()

    def decrypt_all():
        with open("unsorted/passw.txt", "r") as f_read:
            read = f_read.readlines()
            list_decr = []
            for encription in read:
                y = encription.encode()
                x = f.decrypt(bytes(y)).decode()
                list_decr.append(str(x))
            list_decr.insert(0, "Master password:")
        return "\n".join(list_decr)

    def read_passwords():
        print("***Read passwords***")
        i = 0
        while i < 3:
            master_query = input("Enter your master password: ").strip()
            with open("unsorted/passw.txt", "r") as f_read:
                read = f_read.read()
            if master_query == decrypt(master_query):
                print(decrypt_all())
                break
            elif master_query != read:
                print(f"Incorrect master password, you got {2 - i}/3 attempts left")

            i += 1
        return

    def write_passwords():
        print("***Write passwords***")
        i = 0
        while i < 3:
            master_query = input("Enter your master password: ").strip()
            with open("unsorted/passw.txt", "r") as f_read:
                read_line = f_read.readline()
            if read_line == "":
                with open("unsorted/passw.txt", "w") as f_write:
                    f_write.write(encrypt(master_query))
                    print("Your new master password was set\n")
                break
            if master_query == decrypt(master_query):
                new_data = input("Page, login, password: ")
                with open("unsorted/passw.txt", "a") as f_append:
                    f_append.write(f"\n{encrypt(new_data)}")
                print("New data successfully added to database\n")
                break
            elif master_query != decrypt(master_query):
                print(f"Incorrect master password, you got {2 - i}/3 attempts left")
            i += 1
        return

    while True:
        start_input = input("Read your passwords (r), Write new passwords (w), Quit (q): ").lower()
        if start_input == "r":
            with open("unsorted/passw.txt", "r") as f_read:
                if not f_read.read():
                    print("You do not have set any Master password\n")
                    write_passwords()
            read_passwords()
        elif start_input == "w":
            write_passwords()
        elif start_input == "q":
            print("***Quitting***")
            break


if __name__ == '__main__':
    main()



"""
root = Tk()
root.title("Pasword manager")
dimx = 60
dimy = 40

# spacer1 = Label(root, text="").grid(row=0, column=1)
button_r = Button(root, padx=dimx, pady=dimy, text="Read", font=16).grid(row=0, column=0, padx=40, pady=40)
button_w = Button(root, padx=dimx, pady=dimy, text="Write", font=16).grid(row=0, column=2, padx=40, pady=40)

entry_filed1 = Entry(root, width=80, borderwidth=5)
entry_filed1.grid(row=1, column=0, columnspan=3, padx=10, pady=10)

my_label1 = Label(root, text="hello world").grid(row=2, column=0, columnspan=3)

root.mainloop()
"""
#p*i*c*a
