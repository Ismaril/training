import numpy as np
from PIL import Image
from PIL import ImageOps

# text_matrix = {10: "@", 9: "W", 8: "#", 7: "?", 6: "O", 5: "/", 4: "<", 3: "x", 2: ",", 1: ".", 0: " "}
string_matrix = {
    0: "@",
    1: "W",
    2: "#",
    3: "S",
    4: "?",
    5: "O",
    6: "/",
    7: "x",
    8: "<",
    9: ":",
    10: ",",
    11: ".",
    12: " "
}
path_to_photo = "C:/Users/lazni/desktop/lada3.jpg"

with Image.open(path_to_photo) as image:  # open photo
    width, height = image.size  # get image size
    width = width - 1  # reduce by 1 (indexed from 0)
    height = height - 1  # reduce by 1 (indexed from 0)
    image = ImageOps.grayscale(image)  # convert to grayscale
    pixels = image.load()  # pixels object has x and y coordinates for each pixel

    # get a number which represents shade of gray (by x and y coordinates of each pixel)
    # loop starts at [0, 0] and continues till the last pixel of the same row is appended
    #   then next row and on...
    pixel_array = []
    counter = 0
    while counter < height:
        for i, y in enumerate(range(width)):
            pixel_array.append(pixels[width - (width - i), height - (height - counter)])
        counter += 1

    # floor divide 255 shades to match the number of categories of string matrix
    reduced_gray = np.array(pixel_array) // 21.25

    # replace integers by string chars from string matrix
    string_array = []
    for item in reduced_gray:
        string_array.append(string_matrix.get(item))

    # reshape the array to 2D
    reshaped = np.reshape(string_array, (height, width))

    # specify density of string characters in the resulting image
    reduced = np.array(reshaped[::10, ::4]).tolist()
    print(reduced)

    # write to textfile
    with open("picture.txt", "w") as txt:
        for line in reduced:
            txt.writelines(f"{''.join(line)}\n")
    print(np.array(reduced).shape)
