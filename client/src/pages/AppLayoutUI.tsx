import { useContext, useEffect, useState } from "react";
import {
  Avatar,
  Box,
  Button,
  Footer,
  Grommet,
  Heading,
  Layer,
  Text,
  Tab,
  Tabs,
  Header,
  Form,
} from "grommet";
import { Close, FormClose, History, Home, Search, User } from "grommet-icons";
import { AppBar } from "../components/AppBar";
import { theme } from "../components/Theme";
import { useLocation, useNavigate } from "react-router-dom";
import { PagesType, StringToPagesType } from "../enums/PagesType";
import { AuthContext } from "../contexts/AuthContext";

export const AppLayoutUI = (props: any) => {
  const { isAuthenticated, logout } = useContext(AuthContext);
  const [page, setPage] = useState(0);
  const navigate = useNavigate();
  const location = useLocation();
  useEffect(() => {
    onActive(-1);
  }, []);
  const onActive = (nextIndex: number) => {
    if (nextIndex === -1) {
      nextIndex = StringToPagesType(location.pathname);
      setPage(nextIndex);
      return;
    }
    if (nextIndex === 3) {
      onOpen();
      return;
    }
    navigate(PagesType[nextIndex]);
    setPage(nextIndex);
  };

  const [showPopUp, setShowPopUp] = useState(false);

  const onOpen = () => setShowPopUp(true);

  const onClose = () => setShowPopUp(false);

  const onLogout = () => {
    logout().then(() => {
      window.location.reload();
    });
  };

  return (
    <Grommet theme={theme} full>
      <Box fill="vertical" align="center">
        <Box
          width={{ max: "xlarge" }}
          fill="vertical"
          overflow={{ horizontal: "hidden" }}
        >
          {props.children}
        </Box>
        {showPopUp && (
          <Layer modal onClickOutside={onClose} onEsc={onClose}>
            <Box
              width="medium"
              margin={{ horizontal: "large", vertical: "medium" }}
            >
              <Header justify="center">
                <Button
                  onClick={onLogout}
                  color="red"
                  fill
                  type="button"
                  label="Выйти"
                  primary
                />
                <Button type="button" onClick={onClose}>
                  <FormClose />
                </Button>
              </Header>
            </Box>
          </Layer>
        )}
        {isAuthenticated && (
          <>
            <Footer background={"dark-3"}>
              <Box fill="horizontal" pad="medium">
                <Tabs>
                  <Tab icon={<User size="medium" />}></Tab>
                </Tabs>
              </Box>
            </Footer>
            <Layer
              animate={false}
              position="bottom"
              responsive={false}
              modal={false}
              full="horizontal"
            >
              <AppBar>
                <Box fill="horizontal" pad="medium">
                  <Tabs
                    flex
                    justify={"center"}
                    activeIndex={page}
                    onActive={onActive}
                  >
                    <Tab icon={<Home />}></Tab>
                    <Tab icon={<History />}></Tab>
                    <Tab icon={<User />}></Tab>
                    <Tab icon={<Close color="red" />}></Tab>
                  </Tabs>
                </Box>
              </AppBar>
            </Layer>
          </>
        )}
      </Box>
    </Grommet>
  );
};
