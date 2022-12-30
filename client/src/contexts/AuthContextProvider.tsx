import { AuthInfo } from "../objects/AuthInfo";
import { AuthInput } from "../objects/AuthInput";
import { authRepository } from "../repositories/AuthRepository";
import { useEffect, useState } from "react";
import { RoleType } from "../enums/RoleType";
import { AuthContext } from "./AuthContext";
import { useNavigate } from "react-router-dom";

export const AuthContextProvider = ({ children }: any) => {
  // const navigate = useNavigate();
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [role, setRole] = useState(RoleType.Undefined);
  const [loginName, setLoginName] = useState("");
  const [thigs, theThing] = useState(0);
  const navigate = useNavigate();
  useEffect(() => {
    authRepository.getInfo().then((data) => {
      setState(data);
      if (!data.isAuthenticated) {
        navigate("/auth");
      }
    });
  }, []);

  const setState = (authInfo: AuthInfo) => {
    setIsAuthenticated(authInfo.isAuthenticated);
    setRole(authInfo.role);
    setLoginName(authInfo.loginName);
  };

  const login = async (input: AuthInput): Promise<AuthInfo> => {
    let data = await authRepository.login(input);
    setState(data);
    return data;
  };
  const registration = async (input: AuthInput): Promise<AuthInfo> => {
    let data = await authRepository.registration(input);
    setState(data);
    return data;
  };

  const logout = async (): Promise<AuthInfo> => {
    let data = await authRepository.logout();
    setState(data);
    return data;
  };

  return (
    <AuthContext.Provider
      value={{ loginName, isAuthenticated, role, login, registration, logout }}
    >
      {children}
    </AuthContext.Provider>
  );
};
