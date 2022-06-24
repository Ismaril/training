class GenerateDatasets:
    def __init__(self):
        return

    @staticmethod
    def make_squared_distribution(nr_samples=100,
                                  nr_classes=5,
                                  size_1=20,
                                  size_2=40,
                                  scale_spaces=1.3):
        import random
        import numpy as np

        # set random seed for reproducibility
        random.seed(a=10, version=2)
        np.random.seed(10)

        dataset = []
        offset = 0
        for i in range(nr_classes):
            # create X features and y labels as rows
            X_x = np.array([
                random.randint(size_1 + offset,
                               size_2 + offset)
                for _ in range(nr_samples)
            ])
            X_y = np.array([
                random.randint(size_1 - (random.choice([0, size_1])),
                               size_2 + random.choice([0, size_2]))
                for _ in range(nr_samples)
            ])
            y = [i] * nr_samples

            # transform to columns
            columns = np.array([X_x, X_y, y]).T

            dataset.append(columns)

            offset += size_1 * scale_spaces

        # append each separate point distributions under each other in the dataset
        dataset = np.concatenate(dataset)

        # shuffle
        np.random.shuffle(dataset)

        # split to features and labels
        X = dataset[:, 0:2]
        y = dataset[:, -1]
        return X, y

