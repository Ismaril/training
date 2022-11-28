from tkinter import *

PADX_NRS = 40  # pad x numbers only
PADY_ALL = 20
FONT = 16
FG = "white"
BG = "blue"
ICON = "support files/Martz90-Circle-Calculator.ico"

root = Tk()
root.title("Simple calculator")
root.iconbitmap(ICON)
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


button1 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="1", font=FONT, command=lambda: button_click(1)
).grid(row=3, column=0)

button2 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="2", font=FONT, command=lambda: button_click(2)
).grid(row=3, column=1)

button3 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="3", font=FONT, command=lambda: button_click(3)
).grid(row=3, column=2)

button4 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="4", font=FONT, command=lambda: button_click(4)
).grid(row=2, column=0)

button5 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="5", font=FONT, command=lambda: button_click(5)
).grid(row=2, column=1)

button6 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="6", font=FONT, command=lambda: button_click(6)
).grid(row=2, column=2)

button7 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="7", font=FONT, command=lambda: button_click(7)
).grid(row=1, column=0)

button8 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="8", font=FONT, command=lambda: button_click(8)
).grid(row=1, column=1)

button9 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="9", font=FONT, command=lambda: button_click(9)
).grid(row=1, column=2)

button0 = Button(
    root, padx=PADX_NRS, pady=PADY_ALL, text="0", font=FONT, command=lambda: button_click(0)
).grid(row=4, column=0)

button_comma = Button(
    root, padx=42, pady=PADY_ALL, text=".", font=FONT, command=lambda: button_click(".")
).grid(row=4, column=1)

button_calc = Button(
    root, padx=40, pady=PADY_ALL, text="=", font=FONT, command=calculate, bg="black", fg=FG
).grid(row=4, column=2)

button_plus = Button(
    root, padx=38, pady=PADY_ALL, text="+", font=FONT, command=lambda: button_click("+"), bg=BG, fg=FG
).grid(row=1, column=3)

button_minus = Button(
    root, padx=40, pady=PADY_ALL, text="-", font=FONT, command=lambda: button_click("-"), bg=BG, fg=FG
).grid(row=2, column=3)

button_multiply = Button(
    root, padx=39, pady=PADY_ALL, text="*", font=FONT, command=lambda: button_click("*"), bg=BG, fg=FG
).grid(row=3, column=3)

button_divide = Button(
    root, padx=40, pady=PADY_ALL, text="/", font=FONT, command=lambda: button_click("/"), bg=BG, fg=FG
).grid(row=4, column=3)

button_clear = Button(
    root, padx=40, pady=PADY_ALL, text="C", font=FONT, command=button_clear, bg=BG, fg=FG
).grid(row=1, column=5)

button_back_sp = Button(
    root, padx=38, pady=PADY_ALL, text="←", font=FONT, command=back_space, bg=BG, fg=FG
).grid(row=2, column=5)

root.mainloop()
