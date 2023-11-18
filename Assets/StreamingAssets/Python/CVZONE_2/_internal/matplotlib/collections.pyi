from collections.abc import Callable, Iterable, Sequence
from typing import Literal

import numpy as np
from numpy.typing import ArrayLike, NDArray

from . import artist, cm, transforms
from .backend_bases import MouseEvent
from .artist import Artist
from .colors import Normalize, Colormap
from .lines import Line2D
from .path import Path
from .patches import Patch
from .ticker import Locator, Formatter
from .tri import Triangulation
from .typing import ColorType, LineStyleType, CapStyleType, JoinStyleType

class Collection(artist.Artist, cm.ScalarMappable):
    def __init__(
        self,
        *,
        edgecolors: ColorType | Sequence[ColorType] | None = ...,
        facecolors: ColorType | Sequence[ColorType] | None = ...,
        linewidths: float | Sequence[float] | None = ...,
        linestyles: LineStyleType | Sequence[LineStyleType] = ...,
        capstyle: CapStyleType | None = ...,
        joinstyle: JoinStyleType | None = ...,
        antialiaseds: bool | Sequence[bool] | None = ...,
        offsets: tuple[float, float] | Sequence[tuple[float, float]] | None = ...,
        offset_transform: transforms.Transform | None = ...,
        norm: Normalize | None = ...,
        cmap: Colormap | None = ...,
        pickradius: float = ...,
        hatch: str | None = ...,
        urls: Sequence[str] | None = ...,
        zorder: float = ...,
        **kwargs
    ) -> None: ...
    def get_paths(self) -> Sequence[Path]: ...
    def set_paths(self, paths: Sequence[Path]) -> None: ...
    def get_transforms(self) -> Sequence[transforms.Transform]: ...
    def get_offset_transform(self) -> transforms.Transform: ...
    def set_offset_transform(self, offset_transform: transforms.Transform) -> None: ...
    def get_datalim(self, transData: transforms.Transform) -> transforms.Bbox: ...
    def set_pickradius(self, pickradius: float) -> None: ...
    def get_pickradius(self) -> float: ...
    def set_urls(self, urls: Sequence[str | None]) -> None: ...
    def get_urls(self) -> Sequence[str | None]: ...
    def set_hatch(self, hatch: str) -> None: ...
    def get_hatch(self) -> str: ...
    def set_offsets(self, offsets: ArrayLike) -> None: ...
    def get_offsets(self) -> ArrayLike: ...
    def set_linewidth(self, lw: float | Sequence[float]) -> None: ...
    def set_linestyle(self, ls: LineStyleType | Sequence[LineStyleType]) -> None: ...
    def set_capstyle(self, cs: CapStyleType) -> None: ...
    def get_capstyle(self) -> Literal["butt", "projecting", "round"] | None: ...
    def set_joinstyle(self, js: JoinStyleType) -> None: ...
    def get_joinstyle(self) -> Literal["miter", "round", "bevel"] | None: ...
    def set_antialiased(self, aa: bool | Sequence[bool]) -> None: ...
    def get_antialiased(self) -> NDArray[np.bool_]: ...
    def set_color(self, c: ColorType | Sequence[ColorType]) -> None: ...
    def set_facecolor(self, c: ColorType | Sequence[ColorType]) -> None: ...
    def get_facecolor(self) -> ColorType | Sequence[ColorType]: ...
    def get_edgecolor(self) -> ColorType | Sequence[ColorType]: ...
    def set_edgecolor(self, c: ColorType | Sequence[ColorType]) -> None: ...
    def set_alpha(self, alpha: float | Sequence[float] | None) -> None: ...
    def get_linewidth(self) -> float | Sequence[float]: ...
    def get_linestyle(self) -> LineStyleType | Sequence[LineStyleType]: ...
    def update_scalarmappable(self) -> None: ...
    def get_fill(self) -> bool: ...
    def update_from(self, other: Artist) -> None: ...

class _CollectionWithSizes(Collection):
    def get_sizes(self) -> np.ndarray: ...
    def set_sizes(self, sizes: ArrayLike | None, dpi: float = ...) -> None: ...

class PathCollection(_CollectionWithSizes):
    def __init__(
        self, paths: Sequence[Path], sizes: ArrayLike | None = ..., **kwargs
    ) -> None: ...
    def set_paths(self, paths: Sequence[Path]) -> None: ...
    def get_paths(self) -> Sequence[Path]: ...
    def legend_elements(
        self,
        prop: Literal["colors", "sizes"] = ...,
        num: int | Literal["auto"] | ArrayLike | Locator = ...,
        fmt: str | Formatter | None = ...,
        func: Callable[[ArrayLike], ArrayLike] = ...,
        **kwargs,
    ) -> tuple[list[Line2D], list[str]]: ...

class PolyCollection(_CollectionWithSizes):
    def __init__(
        self,
        verts: Sequence[ArrayLike],
        sizes: ArrayLike | None = ...,
        *,
        closed: bool = ...,
        **kwargs
    ) -> None: ...
    def set_verts(
        self, verts: Sequence[ArrayLike | Path], closed: bool = ...
    ) -> None: ...
    def set_paths(self, verts: Sequence[Path], closed: bool = ...) -> None: ...
    def set_verts_and_codes(
        self, verts: Sequence[ArrayLike | Path], codes: Sequence[int]
    ) -> None: ...

class BrokenBarHCollection(PolyCollection):
    def __init__(
        self,
        xranges: Iterable[tuple[float, float]],
        yrange: tuple[float, float],
        **kwargs
    ) -> None: ...
    @classmethod
    def span_where(
        cls, x: ArrayLike, ymin: float, ymax: float, where: ArrayLike, **kwargs
    ) -> BrokenBarHCollection: ...

class RegularPolyCollection(_CollectionWithSizes):
    def __init__(
        self, numsides: int, *, rotation: float = ..., sizes: ArrayLike = ..., **kwargs
    ) -> None: ...
    def get_numsides(self) -> int: ...
    def get_rotation(self) -> float: ...

class StarPolygonCollection(RegularPolyCollection): ...
class AsteriskPolygonCollection(RegularPolyCollection): ...

class LineCollection(Collection):
    def __init__(
        self, segments: Sequence[ArrayLike], *, zorder: float = ..., **kwargs
    ) -> None: ...
    def set_segments(self, segments: Sequence[ArrayLike] | None) -> None: ...
    def set_verts(self, segments: Sequence[ArrayLike] | None) -> None: ...
    def set_paths(self, segments: Sequence[ArrayLike] | None) -> None: ...  # type: ignore[override]
    def get_segments(self) -> list[np.ndarray]: ...
    def set_color(self, c: ColorType | Sequence[ColorType]) -> None: ...
    def set_colors(self, c: ColorType | Sequence[ColorType]) -> None: ...
    def set_gapcolor(self, gapcolor: ColorType | Sequence[ColorType] | None) -> None: ...
    def get_color(self) -> ColorType | Sequence[ColorType]: ...
    def get_colors(self) -> ColorType | Sequence[ColorType]: ...
    def get_gapcolor(self) -> ColorType | Sequence[ColorType] | None: ...


class EventCollection(LineCollection):
    def __init__(
        self,
        positions: ArrayLike,
        orientation: Literal["horizontal", "vertical"] = ...,
        *,
        lineoffset: float = ...,
        linelength: float = ...,
        linewidth: float | Sequence[float] | None = ...,
        color: ColorType | Sequence[ColorType] | None = ...,
        linestyle: LineStyleType | Sequence[LineStyleType] = ...,
        antialiased: bool | Sequence[bool] | None = ...,
        **kwargs
    ) -> None: ...
    def get_positions(self) -> list[float]: ...
    def set_positions(self, positions: Sequence[float] | None) -> None: ...
    def add_positions(self, position: Sequence[float] | None) -> None: ...
    def extend_positions(self, position: Sequence[float] | None) -> None: ...
    def append_positions(self, position: Sequence[float] | None) -> None: ...
    def is_horizontal(self) -> bool: ...
    def get_orientation(self) -> Literal["horizontal", "vertical"]: ...
    def switch_orientation(self) -> None: ...
    def set_orientation(
        self, orientation: Literal["horizontal", "vertical"]
    ) -> None: ...
    def get_linelength(self) -> float | Sequence[float]: ...
    def set_linelength(self, linelength: float | Sequence[float]) -> None: ...
    def get_lineoffset(self) -> float: ...
    def set_lineoffset(self, lineoffset: float) -> None: ...
    def get_linewidth(self) -> float: ...
    def get_linewidths(self) -> Sequence[float]: ...
    def get_color(self) -> ColorType: ...

class CircleCollection(_CollectionWithSizes):
    def __init__(self, sizes: float | ArrayLike, **kwargs) -> None: ...

class EllipseCollection(Collection):
    def __init__(
        self,
        widths: ArrayLike,
        heights: ArrayLike,
        angles: ArrayLike,
        *,
        units: Literal[
            "points", "inches", "dots", "width", "height", "x", "y", "xy"
        ] = ...,
        **kwargs
    ) -> None: ...

class PatchCollection(Collection):
    def __init__(
        self, patches: Iterable[Patch], *, match_original: bool = ..., **kwargs
    ) -> None: ...
    def set_paths(self, patches: Iterable[Patch]) -> None: ...  # type: ignore[override]

class TriMesh(Collection):
    def __init__(self, triangulation: Triangulation, **kwargs) -> None: ...
    def get_paths(self) -> list[Path]: ...
    # Parent class has an argument, perhaps add a noop arg?
    def set_paths(self) -> None: ...  # type: ignore[override]
    @staticmethod
    def convert_mesh_to_paths(tri: Triangulation) -> list[Path]: ...

class _MeshData:
    def __init__(
        self,
        coordinates: ArrayLike,
        *,
        shading: Literal["flat", "gouraud"] = ...,
    ) -> None: ...
    def set_array(self, A: ArrayLike | None) -> None: ...
    def get_coordinates(self) -> ArrayLike: ...
    def get_facecolor(self) -> ColorType | Sequence[ColorType]: ...
    def get_edgecolor(self) -> ColorType | Sequence[ColorType]: ...

class QuadMesh(_MeshData, Collection):
    def __init__(
        self,
        coordinates: ArrayLike,
        *,
        antialiased: bool = ...,
        shading: Literal["flat", "gouraud"] = ...,
        **kwargs
    ) -> None: ...
    def get_paths(self) -> list[Path]: ...
    # Parent class has an argument, perhaps add a noop arg?
    def set_paths(self) -> None: ...  # type: ignore[override]
    def get_datalim(self, transData: transforms.Transform) -> transforms.Bbox: ...
    def get_cursor_data(self, event: MouseEvent) -> float: ...

class PolyQuadMesh(_MeshData, PolyCollection):
    def __init__(
        self,
        coordinates: ArrayLike,
        **kwargs
    ) -> None: ...
