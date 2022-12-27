import { Box } from "grommet";

const AppBar = (props: any) => (
  <Box
    tag="header"
    direction="row"
    align="center"
    justify="between"
    background="brand"
    pad={{ left: "medium", right: "small" }}
    elevation="medium"
    {...props}
  />
);

export { AppBar };
