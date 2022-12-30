export enum PagesType {
  "/" = 0,
  "/history",
  "/profile",
}
export const StringToPagesType = (s: string): PagesType => {
  switch (s) {
    case "/":
      return PagesType["/"];
    case "/profile":
      return PagesType["/profile"];
    case "/history":
      return PagesType["/history"];
  }
  return PagesType["/"];
};
