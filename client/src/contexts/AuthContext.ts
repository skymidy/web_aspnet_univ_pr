import { createContext } from "react";
import { RoleType } from "../enums/RoleType";
import { AuthInfo } from "../objects/AuthInfo";
import { AuthInput } from "../objects/AuthInput";

interface IAuthContext {
  loginName: string;
  // Авторизован ли пользователь
  isAuthenticated: boolean;
  // Роль пользователя
  role: RoleType;
  // Авторизация
  login: (input: AuthInput) => Promise<AuthInfo>;
  // Регистрация
  registration: (input: AuthInput) => Promise<AuthInfo>;
  // Выход
  logout: () => Promise<AuthInfo>;
}

export const AuthContext = createContext<IAuthContext>({
  loginName: "",
  isAuthenticated: false,
  role: RoleType.Undefined,
  login(input: AuthInput): Promise<AuthInfo> {
    throw Error("Отсутствует реализация метода");
  },
  registration(input: AuthInput): Promise<AuthInfo> {
    throw Error("Отсутствует реализация метода");
  },
  logout(): Promise<AuthInfo> {
    throw Error("Отсутствует реализация метода");
  },
});
