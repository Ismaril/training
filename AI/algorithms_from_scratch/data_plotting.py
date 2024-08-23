import matplotlib.pyplot as plt
import numpy as np
from matplotlib import ticker


class Plots:
    def __init__(self):
        pass

    def plot_decision_boundary(self,
                               model,
                               X,
                               y,
                               bound_smoot=100,
                               fig_size=(16, 9),
                               grid=True,
                               verbose=False,
                               cmap="brg",
                               svm_linear=False,
                               svm_poly=False):
        """
        :param model: model that's going to predict y from X
        :param X: features
        :param y: labels
        :param bound_smoot: smoothness of decision boundary, higher number higher smoothness
        :param fig_size: size of figure, enter two value tuple
        :param grid: if True place grid on plot
        :param verbose: print examples how internal data look like
        :param cmap: colormap from matplotlib
        :param svm_linear: if True plot support vectors, applicable only for Support Vector Machines
        """
        # model.fit(X, y)

        # Create a 2D grid of points (Xx, Xy) that we're going to predict on
        x1_min, x1_max = X[:, 0].min(), X[:, 0].max()
        x2_min, x2_max = X[:, 1].min(), X[:, 1].max()
        # Xx and Xy are 2D matrices.
        # Each point from Xx and Xy together form a distinct coordinate.
        Xx, Xy = np.meshgrid(np.linspace(x1_min, x1_max, bound_smoot),
                             np.linspace(x2_min, x2_max, bound_smoot))

        # Create X data (we're going to predict on all of these)
        X_meshgrid = np.c_[Xx.ravel(), Xy.ravel()]

        # Make predictions using the trained model on "matrix of X values"
        y_pred = model.predict(X_meshgrid)
        y_pred = y_pred.reshape(Xx.shape)

        plt.figure(figsize=fig_size)

        plt.xlim(Xx.min(), Xx.max())
        plt.ylim(Xy.min(), Xy.max())
        # Set major tick locator for x-axis and y-axis
        plt.gca().xaxis.set_major_locator(ticker.MultipleLocator(0.5))  # Major ticks every 2 units
        plt.gca().yaxis.set_major_locator(ticker.MultipleLocator(0.5))  # Major ticks every 0.5 units

        # Optionally, set minor tick locator for more granular ticks
        plt.gca().xaxis.set_minor_locator(ticker.MultipleLocator(0.1))  # Minor ticks every 0.5 units
        plt.gca().yaxis.set_minor_locator(ticker.MultipleLocator(0.1))  # Minor ticks every 0.1 units

        # Optionally, enable the grid and show both major and minor ticks
        plt.grid(which='both', linestyle='--', linewidth=0.5)
        plt.grid(grid)

        plt.xlabel("$X_1$")
        plt.ylabel("$X_2$")

        # Plot decision boundary
        plt.contourf(Xx, Xy, y_pred, cmap=cmap, alpha=0.5)

        if svm_linear:
            w = model.coef_[0]
            b = model.intercept_[0]

            x0 = np.linspace(x1_min, x1_max, bound_smoot)
            decision_boundary = -w[0] / w[1] * x0 - b / w[1]

            margin = 1 / w[1]
            support_vector_upper_boundary = decision_boundary + margin
            support_vector_lower_boundary = decision_boundary - margin

            plt.plot(x0, decision_boundary, "k-", linewidth=2, zorder=-2) # White decision boundary.
            plt.plot(x0, support_vector_upper_boundary, "k--", linewidth=2, zorder=-2) # Dashed upper boundary.
            plt.plot(x0, support_vector_lower_boundary, "k--", linewidth=2, zorder=-2) # Dashed lower boundary.
            # Plot support vectors (Mark the support vectors with red circles)
            plt.scatter(model.support_vectors_[:, 0], model.support_vectors_[:, 1], s=180, facecolors='#FF0000',
                        zorder=-1)
        elif svm_poly:
            # Plot support vectors (Mark the support vectors with red circles)
            plt.scatter(model.support_vectors_[:, 0], model.support_vectors_[:, 1], s=180, facecolors='#FF0000', zorder=-1)

        # Plot X data (features)
        plt.scatter(X[:, 0], X[:, 1], c=y, s=40, cmap=cmap, edgecolors="k")

        plt.show()

        if verbose:
            print("xx, yy, x_in, y_pred")
            print(Xx.shape, Xy.shape, X_meshgrid.shape, y_pred.shape, sep="\n" * 2)
            print(Xx[0], Xy[0], X_meshgrid[0], y_pred[0], sep="\n" * 2)
