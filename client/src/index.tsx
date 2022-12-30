import React from "react";
import ReactDOM from "react-dom/client";
import reportWebVitals from "./reportWebVitals";
import {
  createBrowserRouter,
  RouterProvider,
  Route,
  createRoutesFromElements,
  Outlet,
} from "react-router-dom";
import { AuthPage } from "./pages/AuthPage";
import { HomePage } from "./pages/HomePage";
import { RegistrationPage } from "./pages/RegistrationPage";
import { ProfilePage } from "./pages/ProfilePage";
import { PairingPage } from "./pages/PairingPage";
import { PairingRecordsPage } from "./pages/PairingRecordsPage";
import { AuthContextProvider } from "./contexts/AuthContextProvider";
import { profileRepository } from "./repositories/ProfileRepository";
import { AppLayoutUI } from "./pages/AppLayoutUI";
import { Wrapper } from "./pages/Wrapper";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route element={<Wrapper children={<Outlet />} />}>
      <Route index element={<HomePage />} />
      <Route path="/auth" element={<AuthPage />} />
      <Route path="/registration" element={<RegistrationPage />} />
      <Route
        path="/profile/*"
        element={<ProfilePage />}
        // loader={async ({ params }) => {
        //   return profileRepository.getProfile(params["*"]);
        // }}
      />
      <Route path="/pair" element={<PairingPage />} />
      <Route path="/history" element={<PairingRecordsPage />} />
    </Route>
  )
);

root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
