import numpy as np
from PIL import Image
from matplotlib import pyplot as plt


class Pixelize:
    def __init__(self, pixel_density=20, path=None):
        self.pixel_density = pixel_density
        self.path = path
        self.width, self.height, self.pixels = self.get_raw_image()
        self.two_dim_array = self.reshape()

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
        reshaped = np.reshape(self.get_pixel_array(), (self.height, self.width, 3))  # (Y, X, (R,G,B))
        sliced = reshaped[::self.pixel_density, ::self.pixel_density]
        return sliced

    def display_plot(self):
        """Display using matplotlib."""
        plt.imshow(self.reshape())
        plt.show()


path_to_photo = "C:/Users/lazni/desktop/eagle.jpg"

if __name__ == '__main__':
    pix = Pixelize(pixel_density=20, path=path_to_photo)
    pix.get_raw_image()
    pix.get_pixel_array()
    pix.reshape()
    pix.display_plot()
