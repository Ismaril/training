from tkinter import *

root = Tk()
root.title("Simple calculator")
root.iconbitmap("C:/Users/lazni/Downloads/Martz90-Circle-Calculator.ico")

entry_data = Entry(root, width=65, borderwidth=5)
entry_data.grid(row=0, column=0, columnspan=6, padx=10, pady=10)


def button_click(number_sign):
    current = entry_data.get()
    entry_data.delete(0, END)
    entry_data.insert(0, str(current) + str(number_sign))


def button_clear():
    entry_data.delete(0, END)


def back_space():
    entry_data.delete(len(entry_data.get()) - 1)


def calculate():
    list_of_commands = str(entry_data.get())
    entry_data.delete(0, END)
    entry_data.insert(0, eval(list_of_commands))


button1 = Button(root, padx=40, pady=20, text="1", font=16, command=lambda: button_click(1)).grid(row=3,
                                                                                                  column=0)
button2 = Button(root, padx=40, pady=20, text="2", font=16, command=lambda: button_click(2)).grid(row=3,
                                                                                                  column=1)
button3 = Button(root, padx=40, pady=20, text="3", font=16, command=lambda: button_click(3)).grid(row=3,
                                                                                                  column=2)
button4 = Button(root, padx=40, pady=20, text="4", font=16, command=lambda: button_click(4)).grid(row=2,
                                                                                                  column=0)
button5 = Button(root, padx=40, pady=20, text="5", font=16, command=lambda: button_click(5)).grid(row=2,
                                                                                                  column=1)
button6 = Button(root, padx=40, pady=20, text="6", font=16, command=lambda: button_click(6)).grid(row=2,
                                                                                                  column=2)
button7 = Button(root, padx=40, pady=20, text="7", font=16, command=lambda: button_click(7)).grid(row=1,
                                                                                                  column=0)
button8 = Button(root, padx=40, pady=20, text="8", font=16, command=lambda: button_click(8)).grid(row=1,
                                                                                                  column=1)
button9 = Button(root, padx=40, pady=20, text="9", font=16, command=lambda: button_click(9)).grid(row=1,
                                                                                                  column=2)
button0 = Button(root, padx=40, pady=20, text="0", font=16, command=lambda: button_click(0)).grid(row=4,
                                                                                                  column=0)

button_comma = Button(root, padx=42, pady=20, text=".", font=16, command=lambda: button_click(".")).grid(
                    row=4, column=1)
button_calc = Button(root, padx=40, pady=20, text="=", font=16, command=calculate, bg="black",
                     fg="white").grid(row=4, column=2)
button_plus = Button(root, padx=38, pady=20, text="+", font=16, command=lambda: button_click("+"), bg="blue",
                     fg="white").grid(row=1, column=3)
button_minus = Button(root, padx=40, pady=20, text="-", font=16, command=lambda: button_click("-"), bg="blue",
                      fg="white").grid(row=2, column=3)
button_multiply = Button(root, padx=39, pady=20, text="*", font=16, command=lambda: button_click("*"),
                         bg="blue", fg="white").grid(row=3, column=3)
button_divide = Button(root, padx=40, pady=20, text="/", font=16, command=lambda: button_click("/"),
                       bg="blue", fg="white").grid(row=4, column=3)
button_clear = Button(root, padx=40, pady=20, text="C", font=16, command=button_clear, bg="blue",
                      fg="white").grid(row=1, column=5)
button_back_sp = Button(root, padx=38, pady=20, text="←", font=16, command=back_space, bg="blue",
                        fg="white").grid(row=2, column=5)

# puts the window into loop (every gui has to be in loop, to see what has updated from keyboard, mouse etc...)
root.mainloop()
