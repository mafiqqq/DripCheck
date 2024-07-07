import { CanActivateFn, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { inject } from '@angular/core';

import { AuthService } from '../shared/auth.service';

export const authGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot, 
  state: RouterStateSnapshot,
) => {
  const authService: AuthService = inject(AuthService); 
  const router: Router = inject(Router);
  const user = authService.getUser();
  console.log('getr user :' + user);
  const protectedRoutes: string[] = ['/warranty', '/register-product'];
  return protectedRoutes.includes(state.url) && user === 'admin'
    ? true
    : router.navigate(['/']);
};

