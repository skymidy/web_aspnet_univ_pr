import { Box, Button, Heading, Text } from "grommet";
import { Search } from "grommet-icons";
import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../contexts/AuthContext";

export const HomePage = (props: any) => {
  const { loginName, isAuthenticated, role } = useContext(AuthContext);
  return (
    <Box fill justify="center">
      <Button
        justify="start"
        type="button"
        label="Найти ментора"
        margin={"small"}
        icon={<Search />}
      ></Button>
      <Button
        justify="start"
        type="button"
        label="Поиск собеседника"
        margin={"small"}
        icon={<Search />}
      ></Button>
    </Box>
  );
};
