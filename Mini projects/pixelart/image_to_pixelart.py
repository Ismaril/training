import requests
import numpy as np
from PIL import Image
from matplotlib import pyplot as plt


class Pixelize:
    def __init__(self,
                 pixel_density=20,
                 path=None,
                 url=None,
                 name_of_image=None):
        """
        Pixel density => How many pixels to skip in each axis
        Path => Insert path from local machine else None
        Url => Insert url from internet else None
        Save loc => Insert local path
        Name of image => Chose at your will
        """
        self.pixel_density = pixel_density
        self.path = path
        self.url = url
        self.name_of_image = name_of_image
        self.width, self.height, self.pixels = self.get_raw_image()

    def get_raw_image(self) -> (int, int, object):
        # exclude path to image that is not used
        if self.url:
            image_location = requests.get(self.url, stream=True).raw
        else:
            image_location = self.path

        # get raw image
        with Image.open(image_location) as image:
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

        return np.array(rgb_array).flatten()

    @staticmethod
    def convert_to_9_bit(rgb_array):
        """Reduce 255 colors to 8 for each channel"""
        rgb_array = rgb_array()  # iteration below cannot be performed directly on parameter?
        flattened_9bit = []
        rgb_9bit = []

        # return 8 color variants out of 255 colors
        for color in rgb_array:
            if color < 32:
                flattened_9bit.append(0)
            elif 32 <= color < 63:
                flattened_9bit.append(32)
            elif 63 <= color < 95:
                flattened_9bit.append(64)
            elif 95 <= color < 127:
                flattened_9bit.append(96)
            elif 127 <= color < 159:
                flattened_9bit.append(128)
            elif 159 <= color < 191:
                flattened_9bit.append(160)
            elif 191 <= color < 223:
                flattened_9bit.append(192)
            elif 223 <= color < 256:
                flattened_9bit.append(255)

        # convert flattened array back to 3 item object [[R,G,B], ... [R,G,B]]
        rgb_container = []
        for item in flattened_9bit:
            rgb_container.append(item)
            if len(rgb_container) == 3:
                rgb_9bit.append(rgb_container)
                rgb_container = []

        return np.array(rgb_9bit, dtype=int)

    def reshape(self) -> np.ndarray:
        """
        Reshape the array to 2D.
        (Actually 3D if counting also RGB.)
        Slicing with steps [::self.pixel_density] -> Take only each x pixel of given X and Y array.
        """
        rgb_9bit = self.convert_to_9_bit(rgb_array=self.get_pixel_array)
        reshaped = np.reshape(rgb_9bit, (self.height, self.width, 3))  # (Y, X, (R,G,B))
        sliced = reshaped[::self.pixel_density, ::self.pixel_density]
        return sliced

    def plot_prepare(self):
        """Display using matplotlib."""
        plt.figure(figsize=(self.width / 30, self.height / 30))
        plt.imshow(self.reshape())
        plt.axis("off")  # get rid of axis numbers around plot

    def plot_save(self):
        # last two parameters are also made to remove the rest of whit padding etc around plot
        plt.savefig(f"finished images/{self.name_of_image}.png",
                    bbox_inches='tight',
                    pad_inches=0)

    def main(self):
        self.get_raw_image()
        print("Get raw img - done")
        self.get_pixel_array()
        print("Get pixel array - done")
        self.reshape()
        print("Reshaped - done")
        self.plot_prepare()
        print("Prepare plot - done")
        self.plot_save()
        print("Plot saved")
        plt.show()  # display figure


# Operate here ###############################################################
set_pixel_density = 12
set_local_path = None
set_url = ""
set_save_location = True
set_name_of_image = ""


if __name__ == '__main__':
    pix = Pixelize(
        pixel_density=set_pixel_density,
        path=set_local_path,
        url=set_url,
        name_of_image=set_name_of_image
    )
    pix.main()
