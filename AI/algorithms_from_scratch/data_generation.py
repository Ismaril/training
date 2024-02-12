import matplotlib.pyplot as plt
import numpy as np


class GenerateDatasets:
    @staticmethod
    def make_blobs(nr_blobs=4,
                   nr_samples=1000,
                   nr_cols=2,
                   size_left=1,
                   mode=1.5,
                   size_right=2,
                   scale_row=1,
                   scale_col=1,
                   random_seed=True):
        """
        :param nr_blobs: number of blobs/classes you want to create
        :param nr_samples: total number of points on the plot
        :param nr_cols: number of columns to divide blobs into
        :param size_left: select lower range of blob generation
        :param mode: select triangular bias of blob generation
        :param size_right: select upper range of blob generation
        :param scale_row: scale distance of blobs from each other
        :param scale_col: scale distance of blobs from each other
        :param random_seed: return reproducible results if True
        :return: 
        """
        assert nr_cols <= nr_blobs, \
            f"nr_cols <= nr_blobs = {nr_cols <= nr_blobs}"
        assert size_left < size_right, \
            f"size_left < size_right = {size_left < size_right}"
        assert size_left <= mode <= size_right, \
            f"size_left <= mode <= size_right = {size_left <= mode <= size_right}"

        # set random seed for reproducibility
        if random_seed:
            np.random.seed(10)

        nr_samples = nr_samples // nr_blobs
        nr_rows = int(nr_blobs / nr_cols)

        dataset = []
        initial_values = (size_left, mode, size_right)
        scaling_rows = size_left * scale_row
        scaling_cols = size_right * scale_col
        iterations = 0

        for column in range(nr_cols):
            for row in range(nr_rows):
                X_x = np.random.triangular(left=size_left + (scaling_cols * column),
                                           mode=mode + (scaling_cols * column),
                                           right=size_right + (scaling_cols * column),
                                           size=nr_samples)

                X_y = np.random.triangular(left=size_left,
                                           mode=mode,
                                           right=size_right,
                                           size=nr_samples)

                X_z = np.random.triangular(left=size_left,
                                           mode=mode,
                                           right=size_right,
                                           size=nr_samples)

                y = [iterations] * nr_samples

                columns = np.c_[X_x, X_y, X_z, y]  # transform to columns
                dataset.append(columns)

                # increment sizes for each row
                size_left += scaling_rows
                mode += scaling_rows
                size_right += scaling_rows

                iterations += 1

            # return sizes to initial values for each new column
            size_left = initial_values[0]
            mode = initial_values[1]
            size_right = initial_values[2]

        # append each separate point distributions under each other in the dataset
        dataset = np.concatenate(dataset)

        np.random.shuffle(dataset)  # shuffle dataset

        # split to features and labels
        X = dataset[:, 0:-1]
        y = np.array(dataset[:, -1], dtype=int)
        return X, y


"""data = GenerateDatasets()
X, y = data.make_blobs()
plt.scatter(X[:, 0], X[:, 1], c=y, cmap="brg")
plt.show()
"""