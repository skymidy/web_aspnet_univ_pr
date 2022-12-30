import { Button, Avatar, Box, Layer } from "grommet";
import { FormClose } from "grommet-icons";

type SideBarProps = {
  switchSideBar: () => void;
  size: string;
};

export const SideBar = ({ switchSideBar, size }: SideBarProps, props: any) => {
  return (
    <Layer
      position="right"
      full="vertical"
      modal="true"
      onEsc={switchSideBar}
      onClickOutside={switchSideBar}
      {...props}
    >
      {size === "small" && (
        <Box
          direction="row"
          align="center"
          justify="end"
          background="light-3"
          pad={{ left: "medium", right: "small", vertical: "" }}
          elevation="medium"
        >
          <Button
            icon={
              <Avatar>
                <FormClose size={"large"} />
              </Avatar>
            }
            onClick={switchSideBar}
          />
        </Box>
      )}
      <Box
        flex={size !== "small" ? true : undefined}
        fill={size === "small" ? true : undefined}
        width="medium"
        background="light"
        elevation="small"
        align="center"
        justify="center"
      ></Box>
    </Layer>
  );
};
