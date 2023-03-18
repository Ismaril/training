import random
import tkinter as tk
from functools import partial
from PIL import ImageTk, Image

try:
    # Relative path from Python project root folder.
    #   (There are troubles loading, because the name of
    #   my folder is Python = it confuses it with library)
    from Python.constants import PYTHON_TRAINING_PARENT_DIR

    IMAGES_LOCATION = f"{PYTHON_TRAINING_PARENT_DIR}" \
                      f"/projects/primitive_projects/support files/dice"
except Exception as err:
    print(err)
    # Absolute path
    IMAGES_LOCATION = "C:/Users/lazni/PycharmProjects/Training/Python" \
                      "/projects/primitive_projects/support files/dice"

SIDES_OF_DICE = 6


def _roll_a_dice(sides_of_a_dice: int = SIDES_OF_DICE) -> int:
    """Dice logic."""
    return random.randint(1, sides_of_a_dice)


def _button_widget(window: tk.Tk) -> tk.Button:
    """Place button on a window grid."""
    return tk.Button(
        window,
        text="Roll a dice",
        command=partial(_image_widget, window)
    ).grid(row=0, column=0)


def _image_widget(window: tk.Tk) -> None:
    """Place an image on a window grid."""
    image = ImageTk.PhotoImage(
        Image.open(f"{IMAGES_LOCATION}/{_roll_a_dice()}.PNG")
    )
    tk.Label(window, image=image).grid(row=1, column=0)
    window.mainloop()


# todo: Destroy widgets, when they are no longer relevant.

def main() -> None:
    window = tk.Tk()
    _button_widget(window)
    _image_widget(window)


if __name__ == '__main__':
    main()
