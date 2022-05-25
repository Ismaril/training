import re

import numpy as np
from PIL import Image
from matplotlib import pyplot as plt


class Pixelize:
    def __init__(self, pixel_density=20, path=None):
        self.pixel_density = pixel_density
        self.path = path
        self.width, self.height, self.pixels = self.get_raw_image()
        self.two_dim_array = None

    def get_raw_image(self) -> (int, int, object):
        with Image.open(self.path) as image:
            width, height = image.size  # get image size e.g.(1920x1080)
            pixels = image.load()  # pixels object has x and y coordinates for each pixel
            return width, height, pixels

    def get_pixel_array(self) -> np.array:
        """
        Get a tuple which represents (R, G, B)(0-255 for each)
        Loop starts at [0, 0] -> X, Y coordinates and continues till the last pixel of the same row
        is appended, then next row and on...
        """
        rgb_array = []
        counter = 0
        while counter < self.height:
            for i, y in enumerate(range(self.width)):
                # rgb_tuple_24_bit = self.pixels[self.width - (self.width - i),
                #                                self.height - (self.height - counter)]
                # rgb_array.append(self.convert_to_8_bit(rgb_tuple_24_bit))
                rgb_array.append(self.pixels[self.width - (self.width - i),
                                             self.height - (self.height - counter)])
            counter += 1
        return np.array(rgb_array)

    def reshape(self) -> np.ndarray:
        """
        Reshape the array to 2D.
        (Actually 3D if counting also RGB.)

        Slicing with steps [::self.pixel_density] -> Take only each x pixel of given X and Y array.
        """
        print(self.get_pixel_array())
        reshaped = np.reshape(self.get_pixel_array(), (self.height, self.width, 3))  # (Y, X, (R,G,B))
        sliced = reshaped[::self.pixel_density, ::self.pixel_density]
        return sliced

    def convert_to_8_bit(self, rgb_tuple):
        range1 = list(range(31))
        range2 = list(range(31, 63))
        range3 = list(range(63, 95))
        range4 = list(range(95, 127))
        range5 = list(range(127, 159))
        range6 = list(range(159, 191))
        range7 = list(range(191, 223))
        range8 = list(range(223, 255))

        res_8_bit = []
        for color in rgb_tuple:
            if color in range1:
                res_8_bit.append(31)
            elif color in range2:
                res_8_bit.append(63)
            elif color in range3:
                res_8_bit.append(95)
            elif color in range4:
                res_8_bit.append(127)
            elif color in range5:
                res_8_bit.append(159)
            elif color in range6:
                res_8_bit.append(191)
            elif color in range7:
                res_8_bit.append(223)
            elif color in range8:
                res_8_bit.append(255)

        return np.array(res_8_bit, dtype=int)

    def display_plot(self):
        """Display using matplotlib."""
        plt.imshow(self.reshape())
        plt.show()


PATH_TO_PHOTO = "C:/Users/lazni/desktop/eagle.jpg"

if __name__ == '__main__':
    pix = Pixelize(pixel_density=20, path=PATH_TO_PHOTO)
    pix.get_raw_image()
    pix.get_pixel_array()
    pix.reshape()
    pix.display_plot()
