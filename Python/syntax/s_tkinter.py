import tkinter as tk

# WORK WITH IMAGES
# todo: PIL and Pillow cannot exist in the same environment
from PIL import ImageTk, Image


def my_click():
    root2 = tk.Tk()
    my_label3 = tk.Label(root2, text=entry_filed2.get())
    my_label3.grid(row=0, column=0)


# this creates empty window
root = tk.Tk()
root3 = tk.Tk()
# renames the name of the window
root.title("Name of this window")

# create text (create widget label)
my_label1 = tk.Label(root, text="hello world")
my_label2 = tk.Label(root, text="My name is Tom")

# put it onto the screen without any exact coordinates .pack()
# my_label1.pack()

# put the text on screen with exact coordinates
my_label1.grid(row=0, column=0)
my_label2.grid(row=1, column=0)

# buttons
my_button1 = tk.Button(root, text="Button 1")
my_button1.grid(row=0, column=1)

my_button2 = tk.Button(root, text="Button 2", state="disabled")
my_button2.grid(row=1, column=1)

my_button3 = tk.Button(root, text="Button 3", padx=25, pady=25)
my_button3.grid(row=2, column=1)

my_button4 = tk.Button(root, text="Button 4", command=my_click, fg="red",
                       bg="blue")  # fg foreground color, bg background
my_button4.grid(row=3, column=1)

# input fields
entry_filed1 = tk.Entry(root)
entry_filed1.grid(row=0, column=2)

entry_filed2 = tk.Entry(root, width=10, borderwidth=5, bg="yellow", fg="black")
entry_filed2.grid(row=1, column=2)

entry_filed3 = tk.Entry(root)
entry_filed3.grid(row=2, column=2)
entry_filed3.insert(0, "Enter something: ")

# photos
my_image1 = ImageTk.PhotoImage(Image.open("C:/Users/lazni/Downloads/Martz90-Circle-Calculator.ico"))
my_label3 = tk.Label(image=my_image1)
my_label3.grid(row=4, column=4)

# puts the window into loop (every gui has to be in loop, to see what has updated from keyboard, mouse etc...)
root.mainloop()
