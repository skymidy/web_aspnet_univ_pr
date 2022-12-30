import { Header } from "grommet";

const AppBar = (props: any) => (
  <Header
    background="light-3"
    sticky="scrollup"
    {...props}
  />
);

export { AppBar };
